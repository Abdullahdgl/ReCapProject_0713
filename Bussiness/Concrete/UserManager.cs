using Bussiness.Abstract;
using Bussiness.Constants;
using Bussiness.ValidationRules_DogrrulamaKurallari.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		[ValidationAspect(typeof(UserValidator))]
		public IResult Add(User user)
		{
			{
				_userDal.Add(user);
				return new SuccessResult(Messages.UserAdded);

			}
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<User>> GetAll()
		{
		
				return new SuccesDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
		
		
		}

		public IDataResult<User> GetById(int id)
		{
			return new SuccesDataResult<User>(_userDal.Get(c => c.UserId == id));
		}

		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
		}
	}
}
