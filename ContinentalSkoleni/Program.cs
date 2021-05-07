using System;

namespace ContinentalSkoleni
{
	class Program
	{
		static void Main(string[] args)
		{
			var arguments = new Email.Composer.ComposeEmailParameters(
				"michal.jaros@continental.com",
				"Ahoj světe!",
				"radek.zahradnik@msn.com");
			Email.Orchestrator.Orchestrate(arguments);
		}
	}


}

namespace Email
{
	class Orchestrator
	{
		public static void Orchestrate(Composer.ComposeEmailParameters composeEmailParameters)
		{
			Validator.ValidateInputArguments(composeEmailParameters);
			var emailToSend = Composer.ComposeEmail(composeEmailParameters);
			Composer.SendEmail(emailToSend);
		}
	}

	class Validator
	{
		public static void ValidateInputArguments(Composer.ComposeEmailParameters composeEmailParameters)
		{
			if (RecipientValidator.IsInvalid(composeEmailParameters.Recipient))
			{
				throw new ArgumentException("An email recipient is invalid.");
			}

			if (BodyValidator.IsInvalid(composeEmailParameters.Body))
			{
				throw new ArgumentException("An body recipient is invalid.");
			}
		}
	}

	class RecipientValidator
	{
		public static bool IsInvalid(string recipient)
		{
			return true;
		}
	}

	class BodyValidator
	{
		public static bool IsInvalid(string body)
		{
			return true;
		}
	}

	class Composer
	{
		public static void SendEmail(Email emailToSend)
		{
			// Other code
		}

		public static string AppendSignature(string body, string sender)
		{
			return body + "Best Regards\n" + sender;
		}

		public static Email ComposeEmail(ComposeEmailParameters composeEmailParameters)
		{
			var message = AppendSignature(composeEmailParameters.Body, composeEmailParameters.Sender);
			return new Email(composeEmailParameters.Recipient, message, composeEmailParameters.Sender);
		}
		internal class ComposeEmailParameters
		{
			public ComposeEmailParameters(string recipient, string body, string sender)
			{
				Recipient = recipient;
				Body = body;
				Sender = sender;
			}

			public string Recipient { get; private set; }
			public string Body { get; private set; }
			public string Sender { get; private set; }
		}
	}

	class Email
	{
		public string Recipient { get; }
		public string Body { get; }
		public string Sender { get; }

		public Email(string recipient, string body, string sender)
		{
			Recipient = recipient;
			Body = body;
			Sender = sender;
		}
	}
}
