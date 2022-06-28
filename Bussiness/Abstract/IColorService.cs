using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Abstract
{
	public interface IColorService
	{
		IResult add(Color color);
		IResult delete(Color color);
		IResult update(Color color);
		IDataResult<List<Color>> GetAll();
		IDataResult<Color> GetById(int id);
	}
}
