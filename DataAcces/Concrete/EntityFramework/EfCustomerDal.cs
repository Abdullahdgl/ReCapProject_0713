using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAcces.Concrete.EntityFramework
{
	public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
	{
		public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
		{
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cs in filter == null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on cs.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cs.Id,
                                 UserId = u.UserId,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CompanyName = cs.CompanyName
                             };

                return result.ToList();
            }
        }
	}

}