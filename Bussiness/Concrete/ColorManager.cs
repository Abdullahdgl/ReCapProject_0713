using Bussiness.Abstract;
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

		public void add(Color color)
		{
		 _colorDal.Add(color);
			Console.WriteLine("Renk Eklendi.");
		}

		public void delete(Color color)
		{
			_colorDal.Delete(color);
			Console.WriteLine("Renk silindi.");
		}

		public List<Color> GetAll()
		{
			return _colorDal.GetAll();
		}

		public Color GetById(int id)
		{
			return _colorDal.Get(c => c.ColorId == id);
		}

		public void update(Color color)
		{
			_colorDal.Update(color);
			Console.WriteLine("Renk bilgilis güncellendi.");
		}
	}
}
