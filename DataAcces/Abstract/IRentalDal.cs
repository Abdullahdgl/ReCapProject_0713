﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Abstract
{
	public interface IRentalDal : IEntityRepository<Rental>
	{
		List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
	}
}
