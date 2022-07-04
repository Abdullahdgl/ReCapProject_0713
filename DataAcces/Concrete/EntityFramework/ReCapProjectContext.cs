using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
	public class ReCapProjectContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server = DESKTOP-7UIUM7T\SQLEXPRESS; Database = RecapProject; Trusted_Connection = true");
		}
		public DbSet<Car> Cars { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Customer> Customers { get; set; }
		
		public DbSet<User> Users { get; set; }
		public DbSet<Rental> Rentals { get; set; }
	}
}
