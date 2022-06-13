using Bussiness.Concrete;
using DataAcces.Concrete.EntityFramework;
using DataAcces.Concrete.InMemory;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Description);
			}
		}
	}
}
