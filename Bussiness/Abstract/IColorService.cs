using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
	public interface IColorService
	{
		void add(Color color);
		void delete(Color color);
		void update(Color color);
		List<Color> GetAll();
		Color GetById(int id);
	}
}
