using Bussiness.Abstract;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace Bussiness.Concrete
{
	public class CarManager : ICarService

	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}
		public void Add(Car car)
		{
			if (car.Description.Length<=2 && car.DailyPrice>0)
			{
				_carDal.Add(car);
			}
			else
			{
			Console.WriteLine("Bu böyle olmaz arabanın açıklamasını veya günlük ücretini hatalı girdin kontrol et");
			}
		}

		public void Delete(Car car)
		{
			_carDal.Delete(car);
			Console.WriteLine("Başarılı bir şekilde araç silinmiştir.");
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public Car GetById(int id)
		{
			return _carDal.Get(c => c.CarId == id);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			return _carDal.GetCarDetails();
		}

		public List<Car> GetCarsByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);
		}

		public List<Car> GetCarsByColorId(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		public void Update(Car car)
		{
			_carDal.Update(car);
			Console.WriteLine("Başarılı bir şekilde aracı güncelledin.");
		}
	}
}
