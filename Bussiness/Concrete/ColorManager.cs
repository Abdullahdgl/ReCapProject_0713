using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		public IResult add(Color color)
		{
			_colorDal.Add(color);
			return new SuccessResult(Messages.ColorAdded);
		}
		
		


	public IResult delete(Color color)
		{
			_colorDal.Delete(color);
			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new SuccesDataResult<List<Color>>  (_colorDal.GetAll(), Messages.ColorListed);
		}

		public IDataResult<Color> GetById(int id)
		{
			return new SuccesDataResult<Color> (_colorDal.Get(c => c.ColorId == id));
		}

		public IResult update(Color color)
		{
			return new SuccessResult(Messages.ColorUpdated);
		}
	}
}
