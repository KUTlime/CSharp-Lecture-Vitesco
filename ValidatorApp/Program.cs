using System;
using ValidatorLib;

namespace ValidatorApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string testLine = Console.ReadLine();
			string status = Email.Validate(testLine) ? "valid" : "invalid";
			Console.WriteLine($"Testing string {testLine} is {status} email address.");
			Console.ReadKey();
		}
	}
}
