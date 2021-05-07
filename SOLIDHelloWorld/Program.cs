using System;

namespace SOLIDHelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			var message = new Message(new ConsoleReaderWithPrompt(), new ConsoleWriter());
			message.Process();
		}
	}

	interface ITextWriter
	{
		void WriteText(string text);
	}

	interface ITextReader
	{
		string ReadTextFromUser();
	}

	class Message
	{
		public ITextReader Reader { get; }
		public ITextWriter Writer { get; }

		public Message(ITextReader reader, ITextWriter writer)
		{
			Reader = reader;
			Writer = writer;
		}

		public void Process()
		{
			string message = Reader.ReadTextFromUser();
			Writer.WriteText(message);
		}
	}

	class ConsoleReader : ITextReader
	{
		public string ReadTextFromUser()
		{
			return Console.ReadLine();
		}
	}

	class ConsoleReaderWithPrompt : ITextReader
	{
		private readonly ITextReader _reader = new ConsoleReader();
		public string ReadTextFromUser()
		{
			Console.WriteLine("Please, enter some text: ");
			return _reader.ReadTextFromUser();
		}
	}

	class ConsoleWriter : ITextWriter
	{
		public void WriteText(string text)
		{
			Console.WriteLine(text);
		}
	}
}
