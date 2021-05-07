using System;

namespace RefactoringRate
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Amount: {100}, type: {1}, years: {1}, Result: {DiscountRate.Calculate(100, CustomerType.Normal, 1) == 100}");
			Console.WriteLine($"Amount: {100}, type: {2}, years: {1}, Result: {DiscountRate.Calculate(100, CustomerType.Premium, 1) == (decimal)89.1}");
			Console.WriteLine($"Amount: {100}, type: {3}, years: {1}, Result: {DiscountRate.Calculate(100, CustomerType.Gold, 1) == (decimal)69.3}");
			Console.WriteLine($"Amount: {100}, type: {4}, years: {1}, Result: {DiscountRate.Calculate(100, CustomerType.Platinum, 1) == (decimal)49.5}");
			Console.WriteLine($"Amount: {100}, type: {1}, years: {6}, Result: {DiscountRate.Calculate(100, CustomerType.Normal, 6) == 100}");
			Console.WriteLine($"Amount: {100}, type: {2}, years: {6}, Result: {DiscountRate.Calculate(100, CustomerType.Premium, 6) == (decimal)85.5}");
			Console.WriteLine($"Amount: {100}, type: {3}, years: {6}, Result: {DiscountRate.Calculate(100, CustomerType.Gold, 6) == (decimal)66.5}");
			Console.WriteLine($"Amount: {100}, type: {4}, years: {6}, Result: {DiscountRate.Calculate(100, CustomerType.Platinum, 6) == (decimal)47.5}");
		}
	}

	public class DiscountRate
	{
		private const decimal MaxLoyaltyYears = 5;
		public static decimal Calculate(decimal amount, CustomerType type, byte numberOfContractYears)
		{
			if (type == CustomerType.Normal) return amount;
			var loyaltyDiscountRate = GetLoyaltyDiscountRate(numberOfContractYears);
			var customerTypeDiscountRate = GetCustomerTypeDiscountRate(type);
			return (customerTypeDiscountRate * amount) * (1 - loyaltyDiscountRate);
		}

		private static decimal GetLoyaltyDiscountRate(byte numberOfContractYears)
		{
			return (numberOfContractYears > MaxLoyaltyYears) ? MaxLoyaltyYears / 100 : (decimal)numberOfContractYears / 100;
		}

		private static decimal GetCustomerTypeDiscountRate(CustomerType type)
		{
			return type switch
			{
				CustomerType.Normal => 1m,
				CustomerType.Premium => 0.9m,
				CustomerType.Gold => 0.7m,
				CustomerType.Platinum => 0.5m,
				_ => 0
			};
		}
	}

	public enum CustomerType
	{
		Normal,
		Premium,
		Gold,
		Platinum
	}
}
