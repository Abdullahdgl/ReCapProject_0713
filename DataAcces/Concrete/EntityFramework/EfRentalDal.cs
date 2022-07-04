using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				var result = from rn in filter == null ? context.Rentals : context.Rentals.Where(filter)
							 join cr in context.Cars on rn.CarId equals cr.CarId
							 join cs in context.Customers on rn.CustomerId equals cs.Id
							 join br in context.Brands on cr.BrandId equals br.BrandId
							 join u in context.Users on cs.UserId equals u.UserId
							 select new RentalDetailDto
							 {
								 RentalId = rn.Id,
								 BrandName = br.BrandName,
								 CustomerName = u.FirstName + " " + u.LastName,
								 CompanyName = cs.CompanyName,
								 RentDate = rn.RentDate,
								 ReturnDate = rn.ReturnDate,
							 };
				return result.ToList();
			}

		}
	}
}
