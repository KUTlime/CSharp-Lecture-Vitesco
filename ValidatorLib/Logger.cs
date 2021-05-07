using System;

namespace ValidatorLib
{
	public static class Logger
	{
		public static string Path { get; set; } = @"C:\EmailValidator\CheckThisEmails.txt";

		// Singleton type pattern for logging.
		public static void Log(string message)
		{
			throw new NotImplementedException();
		}

		public static void Log(string message, string path)
		{
			throw new NotImplementedException();
		}
	}
}


