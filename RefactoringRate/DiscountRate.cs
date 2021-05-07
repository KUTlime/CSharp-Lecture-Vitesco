namespace RefactoringRate
{
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
}