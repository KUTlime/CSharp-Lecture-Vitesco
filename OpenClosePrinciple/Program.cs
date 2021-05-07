using System;

namespace OpenClosePrinciple
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var czkCurrency = new CZKCurrency() { Value = 10 };
			var czkCurrency2 = new CZKCurrency() { Value = 10 };
			var czkCurrency3 = czkCurrency;

			Console.WriteLine(czkCurrency2 == czkCurrency);
			Console.WriteLine(czkCurrency3 == czkCurrency);
		}

		static void HowToCheckNullInCsharpNine(object input, object someOtherInput)
		{
			if (input is null)
			{
			}

			if (someOtherInput is not null)
			{
			}
		}

		static void Example(MyClass input)
		{
			if (input == null)
			{

			}
		}
	}

	class CZKCurrency
	{
		public Int32 Value { get; set; }
	}

	class MyClass
	{
		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}
		public static bool operator ==(MyClass object1, MyClass object2)
		{
			return true;
		}

		public static bool operator !=(MyClass object1, MyClass object2)
		{
			return !(object1 == object2);
		}

		public static bool operator <=(MyClass object1, MyClass object2)
		{
			return !(object1 == object2);
		}

		public static bool operator >=(MyClass object1, MyClass object2)
		{
			throw new NotImplementedException();
		}
	}

	class SMSSender : IMessageSender
	{
		public bool CanProcess(IMessage message)
		{
			return message.MessageType == MessageType.SMS;
		}

		public bool SendMessage(IMessage message)
		{
			return CanProcess(message) && SendSMS(message.MessageRecipient, message.MessagePayload);
		}

		private bool SendSMS(IMessageRecipient messageRecipient, IMessagePayload messagePayload)
		{
			if (messageRecipient is not SMSRecipient recipient) return false;
			if (messagePayload is not SmsMessagePayload payload) return false;
			return SendSMSToMessageCentre(recipient, payload);
		}

		private bool SendSMSToMessageCentre(SMSRecipient recipient, SmsMessagePayload payload)
		{
			throw new NotImplementedException();
		}
	}

	class SMS : IMessage
	{
		public SMS(string phoneNumber, string textMessage)
		{

		}
		public IMessageRecipient MessageRecipient { get; }
		public IMessagePayload MessagePayload { get; }
		public MessageType MessageType => MessageType.SMS;
	}

	class SmsMessagePayload : IMessagePayload
	{

	}

	class SMSRecipient : IMessageRecipient
	{

	}

	interface IMessageSender
	{
		bool CanProcess(IMessage message);
		bool SendMessage(IMessage message);
	}

	internal interface IMessage
	{
		IMessageRecipient MessageRecipient { get; }
		IMessagePayload MessagePayload { get; }
		MessageType MessageType { get; }
	}

	internal enum MessageType
	{
		SMS
	}

	internal interface IMessagePayload
	{
	}

	internal interface IMessageRecipient
	{
	}
}
