using System;
using System.Linq;

namespace EarlyValidation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Refactored.RegisterUser("radek", "123456");
		}
		private bool ValidUsernameOriginal(string username)
		{
			bool isValid = false;
			const int MinUsernameLength = 6;
			if (username.Length >= MinUsernameLength)
			{
				const int MaxUsernameLength = 25;
				if (username.Length <= MaxUsernameLength)
				{
					bool isAlphaNumeric = username.All(Char.IsLetterOrDigit);
					if (isAlphaNumeric)
					{
						if (!ContainsCurseWords(username))
						{
							isValid = IsUniqueUsername(username);
						}
					}
				}
			}
			return isValid;
		}
		const int MinUsernameLength = 6;
		const int MaxUsernameLength = 25;

		private bool ValidUsername(string username)
		{
			if (username.Length < MinUsernameLength) return false;
			if (username.Length > MaxUsernameLength) return false;
			if (ContainsNotAlphaNumeric(username)) return false;
			if (ContainsCurseWords(username)) return false;
			return IsUniqueUsername(username);
		}

		private static bool ContainsNotAlphaNumeric(string username)
		{
			return !username.All(Char.IsLetterOrDigit);
		}

		private bool IsUniqueUsername(string username)
		{
			throw new NotImplementedException();
		}

		private bool ContainsCurseWords(string username)
		{
			throw new NotImplementedException();
		}
	}

	class Refactored
	{
		public static void RegisterUser(string username, string password)
		{
			ValidateInput(username, password);
			PasswordValidator.Validate(password);
			Console.WriteLine("Registering user...");
		}

		public static void RegisterUserAlternative(string username, string password)
		{
			Console.WriteLine(PasswordValidator.TryValidate(password)
				? "Registering user..."
				: "Your password is invalid.");
		}

		private static void ValidateInput(string username, string password)
		{
			InputValidatorHelper.ValidateInput(username, "Username");
			InputValidatorHelper.ValidateInput(password, "Password");
		}
	}

	class PasswordValidator
	{
		public static void Validate(string password)
		{
			InputValidatorHelper.ValidateInput(password, "Password");
			// aplikace různých pravidel, pravděpodobně privátní metody,
			// délka hesla, síla hesla atd.
			ValidatePasswordLength(password);
		}

		public static bool TryValidate(string password)
		{
			try
			{
				Validate(password);
				return true;
			}
			catch
			{
				return false;
			}
		}

		private static void ValidatePasswordLength(string password)
		{
			if (password.Length < 8)
				throw new ArgumentException("The length of the password has to be more than 8 characters.");
		}
	}

	class InputValidatorHelper
	{
		public static void ValidateInput(string inputToValidate, string parameterName)
		{
			if (string.IsNullOrWhiteSpace(inputToValidate)) throw new ArgumentException($"{parameterName} is required.");
		}
	}
	class Original
	{
		public void RegisterUser(string username, string password)
		{
			if (!string.IsNullOrWhiteSpace(username))
			{
				if (!string.IsNullOrWhiteSpace(password))
				{
					// register user
				}
				else
				{
					throw new ArgumentException("Username is required.");
				}
				throw new ArgumentException("Password is required.");
			}
		}
	}

	class ValidateFromMichal
	{
		public static void ValidateLoginData(string username, string password)
		{
			ValidateUsername(username);
			ValidatePassword(password);
		}

		private static void ValidateUsername(string username)
		{
			if (!string.IsNullOrWhiteSpace(username))
			{
				throw new ArgumentException("Username is required.");
			}
		}

		private static void ValidatePassword(string password)
		{
			if (!string.IsNullOrWhiteSpace(password))
			{
				throw new ArgumentException("Password is required.");
			}
		}
	}
}
