using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public IResult add(Brand brand)
		{
			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);
		}

		public IResult delete(Brand brand)
		{
			_brandDal.Delete(brand);
			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Brand>> GetAll()
		{
		
			return new SuccesDataResult<List<Brand>>(_brandDal.GetAll());

		}

		public IDataResult<Brand> GetById(int id)
		{
			return new SuccesDataResult<Brand> (_brandDal.Get(c => c.BrandId == id));
		}

		public IResult update(Brand brand)
		{
			try
			{
				_brandDal.Update(brand);
				return new SuccessResult(Messages.BrandUpdated);
			}
			catch (Exception)
			{
				return new ErrorResult(Messages.BrandError);
			}
			
				 



		}
	}
}
