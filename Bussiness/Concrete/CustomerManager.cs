using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.UserAdded);
		}

		public IResult Delete(Customer customer)
		{
			_customerDal.Delete(customer);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			if (DateTime.Now.Hour == 13)
			{
				return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(), Messages.UserListed);
			}
			else
			{
				return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
			}
		}

		public IDataResult<Customer> GetById(int Id)
		{
			return new SuccesDataResult<Customer>(_customerDal.Get(c => c.UserId==Id));
		}

		
		public IResult Update(Customer customer)
		{
			_customerDal.Update(customer);
			return new SuccessResult(Messages.UserUpdated);
		}
	}
}
