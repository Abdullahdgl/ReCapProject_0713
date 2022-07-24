using Bussiness.Abstract;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using Core.Utilities.Results;
using Bussiness.Constants;
using Core.Aspects.Autofac.Validation;
using Bussiness.ValidationRules_DogrrulamaKurallari.FluentValidation;
using Core.Utilities.Business;

namespace Bussiness.Concrete
{
	public class CarManager : ICarService

	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
		
		}

		public IResult Delete(Car car)
		{
			var result = BusinessRules.Run(CheckIfCarExists(car.CarId));
			if (result != null)
			{
				return result;
			}

			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<Car>> GetAll()
		{
			if (DateTime.Now.Hour ==22)
			{
				return new SuccesDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
			}
			else
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}
		}

		public IDataResult<Car> GetById(int id)
		{
			return new SuccesDataResult<Car> (_carDal.Get(c => c.CarId == id));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccesDataResult<List<CarDetailDto>>  (_carDal.GetCarDetails());
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			return new SuccesDataResult<List<Car>>  (_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new SuccesDataResult<List<Car>> ( _carDal.GetAll(c => c.ColorId == id));
		}

		public IResult Update(Car car)
		{
			var result = BusinessRules.Run(CheckIfCarExists(car.CarId));
			if (result!=null)
			{
				return result;
			}


			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
		private IResult CheckIfCarExists(int carId)
		{
			if (!(_carDal.GetAll(c=>c.CarId==carId).Count>0))
			{
				return new ErrorResult("Car Not Exits");
			}
			return new SuccessResult();
		}
	}
}
