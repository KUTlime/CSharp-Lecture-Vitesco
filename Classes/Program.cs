using System;

namespace Classes
{
	class Program
	{
		static int Main(string[] args)
		{
			return 0;
		}
	}

	public class MaintenanceComponent
	{
		public void UpdateMaintenancePlan() { }
		public void RemindMaintenance() { }
	}

	public class PaymentServiceProvider
	{
		public void AdjustPrice() { }
		public void ChooseFinancing() { }
		public void CalculateMonthlyPayment() { }
	}

	public class Car
	{
		public void SetSettings() { }
	}


	class Person
	{
		public PersonData Data { get; set; }

		public Person(PersonData data)
		{
			Data = data;
		}

		public void FirstBusinessMethod()
		{
		}

		public void SecondBusinessMethod()
		{
		}
	}

	class PersonData
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UInt16 Age { get; set; }
		public string SocialNumber { get; set; }
		public string Address { get; set; }

		public PersonData(string firstName, string lastName, ushort age, string socialNumber, string address)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			SocialNumber = socialNumber;
			Address = address;
		}
	}
}
