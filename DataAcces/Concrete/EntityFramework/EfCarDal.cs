using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using System.Threading.Tasks;





namespace DataAcces.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext>  ,ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands on c.BrandId equals b.BrandId
							 join cl in context.Colors on c.ColorId equals cl.ColorId

							 select new CarDetailDto

							 {
								 CarName = c.CarName,
								 BrandName = b.BrandName,
								 ColorName = cl.ColorName,
								 DailyPrice = c.DailyPrice

							 };
				return result.ToList();
			}
		}

		
		
	}
}
