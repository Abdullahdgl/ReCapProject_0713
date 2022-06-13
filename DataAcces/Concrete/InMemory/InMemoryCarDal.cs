using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcces.Concrete.InMemory
{
	public class InMemoryCarDal /*: ICarDal*/
	{
		/*List<Car> _cars;
		public InMemoryCarDal() // constrator yapıtığımız alandır.
		{
			_cars = new List<Car>
			{
				new Car {Id = 1 , BrandId = 1 , ColorId = 1 , ModelYear = 2014, DailyPrice = 150, Description ="Nissan 350Z" },
				new Car { Id = 2, BrandId = 1 , ColorId = 1 , ModelYear = 2016, DailyPrice = 1500, Description = "Toyota Supra" },
				new Car { Id = 3, BrandId = 1 , ColorId = 2 , ModelYear = 2017, DailyPrice = 250, Description = "Fiat Doblo" },
				new Car { Id = 4, BrandId = 2 , ColorId = 2 , ModelYear = 2018, DailyPrice = 750, Description = "Audi A3" },
				new Car { Id = 5, BrandId = 2 , ColorId = 2 , ModelYear = 2019, DailyPrice = 800, Description = "Renault Megane" }

			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(CarToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int id)
		{
			return _cars.Where(c => c.Id == id).ToList();
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;

		}
		*/
	}
}
