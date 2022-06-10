using Bussiness.Abstract;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class CarManager : ICarService

	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}
	}
}
