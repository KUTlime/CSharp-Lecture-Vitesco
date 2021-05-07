using System;

namespace Inicialization
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private void Mayfly()
		{
			bool a = false;
			int b = 0;
			string c = string.Empty;
			bool d = true;
			//body continues
			//...
			a = SomethingIsTrue();
			if (a)
			{
				if (c.Length > b)
				{
					//body continues            
					//...           
					d = c.Substring(0, 3) == b.ToString();
				}
			}
		}
		private void MayflyRefactored()
		{
			// Previous code
			if (SomethingIsTrue())
			{
				int b = 0;
				string c = string.Empty;
				if (c.Length > b)
				{
					//body continues            
					//...           
					bool d = c.Substring(0, 3) == b.ToString();
				}
			}
		}
		private bool SomethingIsTrue()
		{
			throw new NotImplementedException();
		}
	}
}
