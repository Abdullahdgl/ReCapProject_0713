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
			Console.WriteLine("****************Car Manager = CarDatabase****************");
			foreach (var car in carManager.GetAll())
			{
				
				Console.WriteLine(car.Description + " " + car.DailyPrice);
			}

			Console.WriteLine("*********** Color Manager = ColorDatabase ***************");
			ColorManager colorManager = new ColorManager(new EfColorDal());
			foreach (var color in colorManager.GetAll())
			{
				Console.WriteLine(color.ColorId + " " + color.ColorName);
			}
			Console.WriteLine("*********** Brand Manager = BrandDatabase ***************");
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			foreach (var brand in brandManager.GetAll())
			{
				Console.WriteLine(brand.BrandId + " " + brand.BrandName);
			}
		}
	}
}
