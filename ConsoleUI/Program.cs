using Bussiness.Concrete;
using DataAcces.Concrete.EntityFramework;
using DataAcces.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarTest();
			ColorTest();
			BrandTest();
			CustomerManagerTest();
			UserManagerTest();

		}

		private static void UserManagerTest()
		{
			Console.WriteLine("*********** User Manager = UserDatabase ***************");
			UserManager userManager = new UserManager(new EfUserDal());
			userManager.Add(new User { FirstName = "Abdullah", LastName = "Dağlı", Email = "adagli@gmail.com", Password = "1234" });
		}

		private static void CustomerManagerTest()
		{
			Console.WriteLine("*********** Customer Manager = CustomerDatabase ***************");

			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			customerManager.Add(new Customer {CompanyName="Koç",UserId = 1});
	

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
			Console.WriteLine("****************Car Manager = CarDatabase****************");
			CarManager carManager = new CarManager(new EfCarDal());
			

			var Result = carManager.GetCarDetails();

			if (Result.Success == true)
			{
				foreach (var car in Result.Data)
				{

					Console.WriteLine(car.CarName + "  " + car.BrandName);
				}
			}
			else
			{
				Console.WriteLine(Result.Message);
			}
		}
	}
}
