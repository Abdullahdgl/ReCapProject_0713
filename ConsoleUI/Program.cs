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
			CarTest();
			//ColorTest();
			//BrandTest();
		}

		private static void BrandTest()
		{
			Console.WriteLine("*********** Brand Manager = BrandDatabase ***************");
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			var Result = brandManager.GetAll();

			foreach (var brand in Result.Data )
			{
				Console.WriteLine(brand.BrandId + " " + brand.BrandName);
			}
		}

		private static void ColorTest()
		{
			Console.WriteLine("*********** Color Manager = ColorDatabase ***************");
			ColorManager colorManager = new ColorManager(new EfColorDal());
			var Result = colorManager.GetAll();

			foreach (var color in Result.Data)
			{
				Console.WriteLine(color.ColorId + " " + color.ColorName);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("****************Car Manager = CarDatabase****************");

			var Result = carManager.GetCarDetails();
			foreach (var car in Result.Data )
			{

				Console.WriteLine( car.DailyPrice + "    /   "+ car.ColorName);
			}
		}
	}
}
