using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using DataAcces.Concrete.EntityFramework;
using Entities.DTOs;

namespace DataAcces.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal() // constrator yapıtığımız alandır.
		{
			_cars = new List<Car>
			{
				new Car {CarId = 1 , BrandId = 1 , ColorId = 1 , ModelYear = 2014, DailyPrice = 150, Description ="Nissan 350Z" },
				new Car { CarId = 2, BrandId = 1 , ColorId = 1 , ModelYear = 2016, DailyPrice = 1500, Description = "Toyota Supra" },
				new Car { CarId = 3, BrandId = 1 , ColorId = 2 , ModelYear = 2017, DailyPrice = 250, Description = "Fiat Doblo" },
				new Car { CarId = 4, BrandId = 2 , ColorId = 2 , ModelYear = 2018, DailyPrice = 750, Description = "Audi A3" },
				new Car { CarId = 5, BrandId = 2 , ColorId = 2 , ModelYear = 2019, DailyPrice = 800, Description = "Renault Megane" }

			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(CarToDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				return context.Set<Car>().SingleOrDefault(filter);
			}
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Car car)
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				//return filter == null
				//		? context.Set<Car>().ToList()
				//		: context.Set<Car>().Where(filter).ToList();
				return _cars;
			}
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public List<Car> GetById(int id)
		{
			return _cars.Where(c => c.CarId == id).ToList();
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;

		}
		
	}
}
