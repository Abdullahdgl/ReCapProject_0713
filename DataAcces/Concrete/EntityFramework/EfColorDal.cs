using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.DataAccess.EntityFramework;

namespace DataAcces.Concrete.EntityFramework
{
	public class EfColorDal : EfEntityRepositoryBase<Color, ReCapProjectContext>, IColorDal
	{
	
	}
}
