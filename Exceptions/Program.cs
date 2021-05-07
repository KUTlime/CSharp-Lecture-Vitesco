using System;
using System.IO;

namespace Exceptions
{
	class Program
	{
		static void Main(string[] args)
		{
			SomeMethod();
		}


		static void SomeMethod()
		{
			try
			{
				SomeOtherMethod();
				SomeOtherMethod();
				SomeOtherMethod();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw new Exception("Invalid state, see details.", innerException: e);
			}
			finally
			{
				Console.WriteLine("A message in finally");
			}
		}

		static void SomeOtherMethod()
		{
			FinalMethod();
		}

		static void FinalMethod()
		{
			throw new SystemException("Hello world!");
		}

		static void SomeRegularMethod()
		{
			// some logic...
			string filePath = GetFilePath();
			string textToWrite = $"[{DateTime.UtcNow}] Some text to write";
			TryWriteToFile(filePath, textToWrite);
		}

		private static void TryWriteToFile(string filePath, string textToWrite)
		{
			try
			{
				File.WriteAllText(filePath, textToWrite);
			}
			catch (DirectoryNotFoundException e)
			{
				// Create Directory
				// Write all text again
			}
			catch (Exception e)
			{
				// exception e handling code...
				throw;
			}
			// Close connection
		}

		private static string GetFilePath()
		{
			return "Test.txt";
		}

		static void WriteToFile(string filePath, string textToWrite)
		{
			throw new ArgumentException("Some error.");
		}
	}
}
