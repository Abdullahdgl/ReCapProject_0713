using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Abstract
{
	public interface ICarDal
	{
		List<Car> GetAll();

		void Add(Car car);
		void Delete(Car car);
		void Update(Car car);

		List<Car> GetById(int id);
	}
}
