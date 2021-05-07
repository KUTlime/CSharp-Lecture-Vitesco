using System;

namespace Factory
{
	class Program
	{
		static void Main(string[] args)
		{
			IProvider provider = ProviderFactory.GetProvider(ParcelDestiny.DeliveryMyParcel);
			provider.GetName();
		}
	}

	enum ParcelDestiny
	{
		LostMyParcel,
		DeliveryMyParcel
	}

	class ProviderFactory
	{
		public static IProvider GetProvider(ParcelDestiny parcelDestiny)
		{
			return parcelDestiny switch
			{
				ParcelDestiny.LostMyParcel => new CzechPost(),
				ParcelDestiny.DeliveryMyParcel => new DPD(),
				_ => throw new ArgumentOutOfRangeException(nameof(parcelDestiny), parcelDestiny, null)
			};
		}
	}

	interface IProvider
	{
		void GetName();
	}

	class CzechPost : IProvider
	{
		public void GetName()
		{
			Console.WriteLine("Zdraví Česká pošta!");
		}
	}

	class DPD : IProvider
	{
		public void GetName()
		{
			Console.WriteLine("Zdraví Distributed Parcel Delivery");
		}
	}
}
