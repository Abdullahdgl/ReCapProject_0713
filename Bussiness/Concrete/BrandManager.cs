using Bussiness.Abstract;
using DataAcces.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void add(Brand brand)
		{
			_brandDal.Add(brand);
			Console.WriteLine("Marka Eklendi.");
		}

		public void delete(Brand brand)
		{
			_brandDal.Delete(brand);
			Console.WriteLine("Marka Silindi.");
		}

		public List<Brand> GetAll()
		{
			return _brandDal.GetAll();
		}

		public Brand GetById(int id)
		{
			return _brandDal.Get(c => c.BrandId == id);
		}

		public void update(Brand brand)
		{
			if (brand.BrandName.Length>=2)
			{
				_brandDal.Update(brand);
				Console.WriteLine("Marka Güncellendi.");
			}
			else
			{
				Console.WriteLine($"Lütfen marka isminin uzunluğunu 1 karakterden fazla giriniz. Girdiğiniz marka ismi : {brand.BrandName}");
			}
			
		}
	}
}
