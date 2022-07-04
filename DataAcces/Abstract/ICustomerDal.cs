﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Abstract
{
	public interface ICustomerDal : IEntityRepository<Customer>
	{
		List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null);
	}
}
