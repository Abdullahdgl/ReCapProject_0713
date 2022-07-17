using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules_DogrrulamaKurallari.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class RentalManager :IRentalService

	{
		IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
		{
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.RentalAdded);
		}
		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Messages.RentalDeleted);
		}
		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
		}
		public IDataResult<Rental> GetById(int rentalId)
		{
			return new SuccesDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
		}
		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccesDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Messages.RentalUpdated);
		}

	}
}
