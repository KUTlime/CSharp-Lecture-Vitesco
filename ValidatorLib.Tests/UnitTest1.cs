using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace ValidatorLib.Tests
{
	[TestClass]
	public class UnitTestEmailValidator
	{
		private static StringBuilder _invalidEmails = new StringBuilder(500);

		[ClassInitialize]
		public static void TestSetUp(TestContext testContext)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(Logger.Path));
			//if file exist, delete content
			File.WriteAllText(Logger.Path, string.Empty);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("radek@zahradnik.cz")]
		[DataRow("radek@tint.zahradnik.cz")]
		[DataRow("rad@zahradnik.cz")]
		[DataRow("zdenek@neustupa.cz")]
		[DataRow("tom@tom.cz")]
		[DataRow("tom.tom@tom.cz")]
		[DataRow("radek@zahradnik.sk")]
		[DataRow("radek@tint.zahradnik.sk")]
		[DataRow("rad@zahradnik.sk")]
		[DataRow("zdenek@neustupa.sk")]
		[DataRow("tom@tom.sk")]
		[DataRow("tom.tom@tom.sk")]
		[DataRow("radek@zahradnik.com")]
		[DataRow("radek@tint.zahradnik.com")]
		[DataRow("rad@zahradnik.com")]
		[DataRow("zdenek@neustupa.com")]
		[DataRow("tom@tom.com")]
		[DataRow("tom.tom@tom.com")]
		public void ValidEmailTests(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsTrue(status);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("radek@zahradnik.gov")]
		[DataRow("radek@tint.zahradnik.gov")]
		[DataRow("rad@zahradnik.gov")]
		[DataRow("rad.zah@zahradnik.gov")]
		[DataRow("radek@zahradnik.ui")]
		[DataRow("radek@tint.zahradnik.ui")]
		[DataRow("rad@zahradnik.ui")]
		[DataRow("rad.zah@zahradnik.ui")]
		public void InvalidTopDomain(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
			using (System.IO.StreamWriter file =
				new System.IO.StreamWriter(Logger.Path, true))
			{
				file.WriteLine(input);
			}
			_invalidEmails.AppendLine(input);
		}


		[TestMethod]
		[DataTestMethod]
		[DataRow("radek@tint.czech.zahradnik.cz")]
		[DataRow("radek@tint..zahradnik.cz")]
		[DataRow("radek@tint.czech.zahradnik.sk")]
		[DataRow("radek@tint..zahradnik.sk")]
		[DataRow("radek@tint.czech.zahradnik.com")]
		[DataRow("radek@tint..zahradnik.com")]
		public void InvalidSubDomain(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("ra@tint.czech.zahradnik.cz")]
		[DataRow("ra@tint.czech.zahradnik.sk")]
		[DataRow("ra@tint.czech.zahradnik.com")]
		[DataRow("ra@tint.zahradnik.cz")]
		[DataRow("ra@tint.zahradnik.sk")]
		[DataRow("ra@tint.zahradnik.com")]
		[DataRow("r.a@tint.zahradnik.cz")]
		[DataRow("r.a@tint.zahradnik.sk")]
		[DataRow("r.a@tint.zahradnik.com")]
		[DataRow("r.a@zahradnik.cz")]
		[DataRow("r.a@zahradnik.sk")]
		[DataRow("r.a@zahradnik.com")]
		[DataRow("radek@za.cz")]
		[DataRow("radek@za.sk")]
		[DataRow("radek@za.com")]
		[DataRow("radek@z.a.cz")]
		[DataRow("radek@z.a.sk")]
		[DataRow("radek@z.a.com")]
		[DataRow("radekzahradnik.radekzahradnik.radekzahradnik.radekzahradnik@zahradnik.cz")]
		[DataRow("radekzahradnik.radekzahradnik.radekzahradnik.radekzahradnik@zahradnik.sk")]
		[DataRow("radekzahradnik.radekzahradnik.radekzahradnik.radekzahradnik@zahradnik.com")]
		[DataRow("radekzahradnikradekzahradnikradekzahradnikradekzahradnik@zahradnik.cz")]
		[DataRow("radekzahradnikradekzahradnikradekzahradnikradekzahradnik@zahradnik.sk")]
		[DataRow("radekzahradnikradekzahradnikradekzahradnikradekzahradnik@zahradnik.com")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahradnik.cz")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahradnik.sk")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahradnik.com")]
		[DataRow("radekzahradnik@radekzahradnik.radekzahradnikradekzahradnik.cz")]
		[DataRow("radekzahradnik@radekzahradnik.radekzahradnikradekzahradnik.sk")]
		[DataRow("radekzahradnik@radekzahradnik.radekzahradnikradekzahradnik.com")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahrad.nik.cz")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahrad.nik.sk")]
		[DataRow("radekzahradnik@radekzahradnikradekzahradnikradekzahrad.nik.com")]
		public void InvalidLength(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("øádek@zahradník.cz")]
		[DataRow("øádek@zahradník.sk")]
		[DataRow("øádek@zahradník.com")]
		[DataRow("øádek@zahradnik.cz")]
		[DataRow("øádek@zahradnik.sk")]
		[DataRow("øádek@zahradnik.com")]
		[DataRow("radek@zahradník.cz")]
		[DataRow("radek@zahradník.sk")]
		[DataRow("radek@zahradník.com")]
		public void InvalidCharacters(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("rad@ek@zahradnik.cz")]
		[DataRow("rad@ek@zahradnik.sk")]
		[DataRow("rad@ek@zahradnik.com")]
		[DataRow("rad@ek@zahradník.cz")]
		[DataRow("rad@ek@zahradník.sk")]
		[DataRow("rad@ek@zahradník.com")]
		[DataRow("radek@zahr@dník.com")]
		[DataRow("radek@zahr@dnik.com")]
		[DataRow("radek@zahr@dnik.sk")]
		[DataRow("radek@zahr@dnik.cz")]
		public void MoreThanOneAt(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow("asdf@asdf.cz")]
		[DataRow("asdf@asdf.sk")]
		[DataRow("asdf@asdf.com")]
		public void BanList(string input)
		{
			bool status = Email.Validate(input);
			Assert.IsFalse(status);
		}

		[ClassCleanup]
		public static void LogTest()
		{
			string content = File.ReadAllText(Logger.Path);
			Assert.AreEqual(_invalidEmails.ToString(), content);
		}

	}
}
