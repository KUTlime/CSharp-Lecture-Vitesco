using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactoringRate.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private const byte One = 1;
		private const byte Two = 2;
		private const byte Three = 3;
		private const byte Four = 4;
		private const byte Five = 5;
		private const byte Six = 6;

		[TestMethod]
		[DataTestMethod]
		[DataRow(100, One, 100)]
		[DataRow(100, Two, 100)]
		[DataRow(100, Three, 100)]
		[DataRow(100, Four, 100)]
		[DataRow(100, Five, 100)]
		[DataRow(100, Six, 100)]
		[DataRow(1000, One, 1000)]
		[DataRow(1000, Two, 1000)]
		[DataRow(1000, Three, 1000)]
		[DataRow(1000, Four, 1000)]
		[DataRow(1000, Five, 1000)]
		[DataRow(1000, Six, 1000)]
		public void CalculateDiscountForNormalCustomersTests(int amount, byte numberOfLoyaltyYears, int expectedValue)
		{
			// Act
			var value = DiscountRate.Calculate(amount, CustomerType.Normal, numberOfLoyaltyYears);
			// Assert
			Assert.AreEqual(expected: expectedValue, actual: value);
		}

		[TestMethod]
		[DataTestMethod]
		[DataRow(100, One, 100)]
		[DataRow(100, Two, 100)]
		[DataRow(100, Three, 100)]
		[DataRow(100, Four, 100)]
		[DataRow(100, Five, 100)]
		[DataRow(100, Six, 100)]
		[DataRow(1000, One, 1000)]
		[DataRow(1000, Two, 1000)]
		[DataRow(1000, Three, 1000)]
		[DataRow(1000, Four, 1000)]
		[DataRow(1000, Five, 1000)]
		[DataRow(1000, Six, 1000)]
		public void CalculateDiscountForPlatinumCustomersTests(int amount, byte numberOfLoyaltyYears, int expectedValue)
		{
			// Act
			var value = DiscountRate.Calculate(amount, CustomerType.Platinum, numberOfLoyaltyYears);
			// Assert
			Assert.AreEqual(expected: expectedValue, actual: value);
		}
	}
}
