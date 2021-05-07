using System;
using System.Collections.Generic;

namespace ComplexConditions
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	class Uploader
	{
		public void UploadFile(System.IO.FileInfo fileToUpload, System.Security.Principal.GenericIdentity user)
		{
			if (FileExtensionValidator.IsSupportedExtension(fileToUpload.Extension) &&
				FilePermissionValidator.IsUserPermittedToAccess(fileToUpload, user))
			{
				// Some Upload logic
			}
		}
	}

	class FileExtensionValidator
	{
		private static readonly List<string> SupportedFileExtensions = new() { ".mp4", ".mpg", ".avi" };
		public static bool IsSupportedExtension(string extensionToTest)
		{
			return SupportedFileExtensions.Contains(extensionToTest);
		}
	}

	class FilePermissionValidator
	{
		public static bool IsUserPermittedToAccess(System.IO.FileInfo file, System.Security.Principal.GenericIdentity user)
		{
			return IsAdmin(user) && IsPermitted(user, file);
		}

		private static bool IsAdmin(System.Security.Principal.GenericIdentity user)
		{
			return true;
		}

		private static bool IsPermitted(System.Security.Principal.GenericIdentity user, System.IO.FileInfo file)
		{
			return true;
		}
	}
}
