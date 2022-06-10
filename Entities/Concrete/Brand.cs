using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Brand:ICar
	{
		public int BrandId { get; set; }
		public String BrandName { get; set; }
	}
}
