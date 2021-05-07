using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiC
{
	class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddScoped<ILogger, Logger>();
			serviceCollection.AddScoped<IMapper, Mapper>();
			serviceCollection.AddSingleton<SomeClass>();
			var serviceProvider = serviceCollection.BuildServiceProvider();

			using (var scope = serviceProvider.CreateScope())
			{
				var someClass = serviceProvider.GetService<SomeClass>();
				someClass.SomeMethod();
			}
		}
	}

	class SomeClass
	{
		public ILogger Logger { get; }
		public IMapper Mapper { get; }

		public SomeClass(ILogger logger, IMapper mapper)
		{
			Logger = logger;
			Mapper = mapper;
		}

		public void SomeMethod()
		{
			var value = Mapper.MapSomething();
			Logger.LogInfo(value.ToString());
		}
	}

	internal interface IMapper
	{
		object MapSomething();
	}

	internal interface ILogger
	{
		void LogInfo(string message);

		void LogException(string message);
	}

	class Mapper : IMapper
	{
		public object MapSomething()
		{
			return "Test";
		}
	}

	class Logger : ILogger
	{
		public void LogInfo(string message)
		{
			Console.WriteLine(message);
		}

		public void LogException(string message)
		{
			throw new NotImplementedException();
		}
	}
}
