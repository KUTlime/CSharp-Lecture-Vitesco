using System;

namespace InversionOfControlViaPolymorphism
{
	class Program
	{
		static void Main(string[] args)
		{
			User user = new BlockedUser();
			user.Login();
			user.GetName();
			user = new InactiveUser();
			user.Login();
			user.GetName();
			var anotherUser = user as InactiveUser;
			anotherUser.GetName();

			var validatePersonDataArguments = new ValidatePersonDataArguments("radek", "zahradník", "123456", 35, "Brno");

			Validate.ValidatePersonData(validatePersonDataArguments);
			Validate.ValidateSomethingElse("Test.txt", includingExtension: true);
		}
	}


	public record ValidatePersonDataArguments(string FirstName, string LastName, string SocialNumber, ushort Age, string Address);

	class Validate
	{
		public static bool ValidatePersonData(ValidatePersonDataArguments validatePersonDataArguments)
		{
			// validatePersonDataArguments.Address = "";
			return true;
		}

		public string Type { get; init; }

		public static bool ValidateSomethingElse(string filePath, bool includingExtension)
		{
			return true;
		}

	}

	abstract class User
	{
		public abstract void Login();

		public virtual void GetName()
		{
			Console.WriteLine("Base method.");
		}
	}

	class InactiveUser : User

	{
		public override void Login()
		{
			Console.WriteLine("Inactive user");
		}

		public new void GetName()
		{
			Console.WriteLine("Name of inactive user.");
		}
	}

	class BlockedUser : User
	{
		public override void Login()
		{
			Console.WriteLine("Blocked user");
		}
	}
}
