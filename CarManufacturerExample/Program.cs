using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CarManufacturerExample
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManufacturer carProvider = CarManufacturerFactory.GetManufacturer(CarManufacture.Skoda) as CarManufacturer;
			ICar car = carProvider.GetCrossOver();
			Console.WriteLine(car.Type);
			Console.WriteLine(string.Join(" ", carProvider.GetManufacturerModels().Select(c => c.Type)));
			carProvider = CarManufacturerFactory.GetManufacturer(CarManufacture.BMW) as CarManufacturer;
			car = carProvider.GetCrossOver();
			Console.WriteLine(string.Join(" ", carProvider.GetManufacturerModels().Select(c => c.Type)));
			Console.WriteLine(car.Type);
		}
	}

	class SkodaAuto : CarManufacturer
	{
		public SkodaAuto(ICarModelFactory modelFactory) : base(modelFactory)
		{
		}
	}

	class BMW : CarManufacturer
	{
		public BMW(ICarModelFactory modelFactory) : base(modelFactory)
		{
		}
	}

	class BMWCarModelFactory : CarModelFactory
	{
		public BMWCarModelFactory(Dictionary<CarType, ICar> dictionary) : base(dictionary)
		{
		}
	}

	class SkodaCarModelFactory : CarModelFactory
	{
		public SkodaCarModelFactory(Dictionary<CarType, ICar> dictionary) : base(dictionary)
		{
		}
	}

	abstract class CarManufacturer : ICarManufacturer
	{
		public ICarModelFactory CarModelFactory { get; }

		public CarManufacturer(ICarModelFactory modelFactory)
		{
			CarModelFactory = modelFactory;
		}

		public ICar GetSUV()
		{
			return CarModelFactory.GetModel(CarType.SUV);
		}

		public ICar GetSedan()
		{
			return CarModelFactory.GetModel(CarType.Sedan);
		}

		public ICar GetCrossOver()
		{
			return CarModelFactory.GetModel(CarType.CrossOver);
		}

		public IEnumerable<ICar> GetManufacturerModels()
		{
			return CarModelFactory.GetModels();
		}
	}

	abstract class CarModelFactory : ICarModelFactory
	{
		protected readonly Dictionary<CarType, ICar> _cars;

		public CarModelFactory(Dictionary<CarType, ICar> dictionary)
		{
			_cars = dictionary;
		}
		public ICar GetModel(CarType type)
		{
			return _cars[type];
		}

		public IEnumerable<ICar> GetModels()
		{
			return _cars.Select(i => i.Value).ToImmutableList();
		}
	}

	class CarCollectionFactory
	{
		public static Dictionary<CarType, ICar> GetCarCollection(CarManufacture manufacture)
		{
			return manufacture switch
			{
				CarManufacture.Skoda => new Dictionary<CarType, ICar>()
				{
					[CarType.Sedan] = new Superb(),
					[CarType.CrossOver] = new Karoq(),
					[CarType.SUV] = new Kodiaq()
				},
				CarManufacture.BMW => new Dictionary<CarType, ICar>()
				{
					[CarType.Sedan] = new M3(),
					[CarType.CrossOver] = new X3(),
					[CarType.SUV] = new X5(),
					[CarType.HatchBack] = new S3()
				},
				_ => throw new ArgumentOutOfRangeException(nameof(manufacture), manufacture, null)
			};
		}
	}

	class CarManufacturerFactory
	{
		public static ICarManufacturer GetManufacturer(CarManufacture type)
		{
			return type switch
			{
				CarManufacture.Skoda => new SkodaAuto(
					new SkodaCarModelFactory(CarCollectionFactory.GetCarCollection(CarManufacture.Skoda))),
				CarManufacture.BMW => new BMW(
					new BMWCarModelFactory(CarCollectionFactory.GetCarCollection(CarManufacture.BMW))),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}
	}

	class X3 : ICar
	{
		public string Type { get; } = "Hello, I'm BMW X3";
		public CarType CarType { get; } = CarType.CrossOver;
	}

	class X5 : ICar
	{
		public string Type { get; } = "Hello, I'm BMW X5";
		public CarType CarType { get; } = CarType.SUV;
	}

	class M3 : ICar
	{
		public string Type { get; } = "Hello, I'm BMW M5";
		public CarType CarType { get; } = CarType.Sedan;
	}


	class Kodiaq : ICar
	{
		public string Type { get; } = "Hello, I'm Škoda Kodiaq";
		public CarType CarType { get; } = CarType.SUV;
	}

	class Karoq : ICar
	{
		public string Type { get; set; } = "Hello, I'm Škoda Karoq";
		public CarType CarType { get; set; } = CarType.CrossOver;
	}

	class Superb : ICar
	{
		public string Type { get; set; } = "Hello, I'm Škoda SuperB";
		public CarType CarType { get; set; } = CarType.Sedan;
	}

	internal class S3 : ICar
	{
		public string Type { get; } = "Hello, I'm S3 model.";
		public CarType CarType { get; } = CarType.HatchBack;
	}

	public interface ICarModelFactory
	{
		ICar GetModel(CarType type);
		IEnumerable<ICar> GetModels();
	}

	public interface ICar
	{
		public string Type { get; }
		public CarType CarType { get; }
	}

	public interface ICarManufacturer
	{
		public ICar GetSUV();
		public ICar GetSedan();
		public ICar GetCrossOver();
	}

	public enum CarManufacture
	{
		Skoda,
		BMW
	}

	public enum CarType
	{
		SUV,
		Sedan,
		CrossOver,
		HatchBack
	}


}
