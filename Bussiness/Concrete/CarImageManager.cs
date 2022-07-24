using Bussiness.Abstract;
using Bussiness.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelperManager;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;
		public CarImageManager(ICarImageDal carImageDal , IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;

		}

		public IResult Add(IFormFile file, CarImage carImage)
		{
			//İş Kodlarımız.
			IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
			if (result!=null)
			{
				return result;

			}

			carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
			carImage.Date = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult("Resim Başarıyla Yüklendii");
		}

		public IResult Delete(CarImage carImage)
		{
			_fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
			_carImageDal.Delete(carImage);
			return new SuccessResult("İlgili Aracın ilgili resmi silindi.");
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll());
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{
			var result = BusinessRules.Run(CheckCarImage(int carId));
			if (result != null)
			{
				return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
			}

			return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));

		}

		public IDataResult<CarImage> GetByImageId(int imageId)
		{
			return new SuccesDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
		}

		public IResult Update(IFormFile file, CarImage carImage)
		{
			carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath, PathConstants.ImagesPath + carImage.ImagePath);
			carImage.Date = DateTime.Now;
			_carImageDal.Update(carImage);
			return new SuccessResult("İlgili Aracın Resmi Güncellenmiştir.");

		}

		private IResult CheckIfCarImageLimit(int CarId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == CarId).Count;
			if (result >=5)
			{
				return new ErrorResult("Bir Araca En fazla 5 fotograf yüklenebilir.");
			}
			return new SuccessResult();
		}
		private IResult CheckCarImage(int carId)
		{
			var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
			if (result > 0)
			{
				return new SuccessResult();
			}
			return new ErrorResult();
		}

		private IDataResult<List<CarImage>> GetDefaultImage(int carId)
		{
			List<CarImage> carImage = new List<CarImage>();
			carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\Upload\\DefaultImage.jpg" });
			return new SuccesDataResult<List<CarImage>>(carImage);
		}

	}
}
