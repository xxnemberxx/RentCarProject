using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleImageManager : IVehicleImageService
    {
        private IVehicleImageDal _vehicleImageDal;
        private IVehicleService _vehicleService;
        public VehicleImageManager(IVehicleImageDal vehicleImageDal, IVehicleService vehicleService)
        {
            _vehicleImageDal = vehicleImageDal;
            _vehicleService = vehicleService;
        }
        [ValidationAspect(typeof(VehicleImageValidator))]
        public async Task<IResult> AddAsync(IFormFile file, VehicleImage vehicleImage)
        {
            var result = BusinessRules.Run(
                CheckIfExceedsUploadQuantity(vehicleImage.VehicleId, 5),
                CheckIfImageTypeInvalid(Path.GetExtension(file.FileName)),
                CheckIfVehicle(vehicleImage.VehicleId)
                );

            if (!result.Success) return result;

            vehicleImage.ImgPath = FileHelper.Upload(file, Settings.ImgPath);
            vehicleImage.ImgName = vehicleImage.ImgPath.Substring(0, vehicleImage.ImgPath.LastIndexOf('.'));
            vehicleImage.ImgExtension = Path.GetExtension(file.FileName);
            vehicleImage.ImgSize = file.Length;

            await _vehicleImageDal.AddAsync(vehicleImage);

            return new SuccessResult();
        }

        public IResult Delete(VehicleImage vehicleImage)
        {
            var result = BusinessRules.Run(CheckIfImageOfTheVehicle(vehicleImage.VehicleId));
            if (!result.Success) return result;

            FileHelper.Delete(Settings.ImgPath + vehicleImage.ImgPath);
            _vehicleImageDal.Remove(vehicleImage);

            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<VehicleImage>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<VehicleImage>>
                (await _vehicleImageDal.GetAllAsync());
        }

        public IDataResult<VehicleImage> GetById(int imgId)
        {
            BusinessRules.Run(CheckIfImage(imgId));
            return new SuccessDataResult<VehicleImage>
                (_vehicleImageDal.GetById<int>(imgId));
        }

        public IDataResult<IEnumerable<VehicleImage>> GetImagesByCarId(short vehicleId)
        {
            return new SuccessDataResult<IEnumerable<VehicleImage>>
                (_vehicleImageDal.GetAll(img => img.VehicleId == vehicleId));
        }

        public IResult Update(IFormFile file, VehicleImage vehicleImage)
        {

            vehicleImage.ImgPath = FileHelper.Update
                (file, Settings.ImgPath + vehicleImage.ImgPath, Settings.ImgPath);

            vehicleImage.ImgName = vehicleImage.ImgPath.Substring(0, vehicleImage.ImgPath.LastIndexOf('.'));
            vehicleImage.ImgExtension = Path.GetExtension(file.FileName);
            vehicleImage.ImgSize = file.Length;

            _vehicleImageDal.Update(vehicleImage);

            return new SuccessResult();
        }
        private IResult CheckIfImage(int imgId)
        {
            var result = _vehicleImageDal.GetById<int>(imgId);
            if(result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotImage);
        }
        private IResult CheckIfVehicle(short vehicleId) 
        {
            return (Result)_vehicleService.GetById(vehicleId);
        }
        private IResult CheckIfImageTypeInvalid(string imgType)
        {
            if (imgType == ".jpg" || imgType == ".png" || imgType == ".jpeg")
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.ContentTypeOfImageNotSupport);
        }
        private IResult CheckIfExceedsUploadQuantity(short vehicleId, int limit)
        {
            var result = _vehicleImageDal.GetAll(img => img.VehicleId == vehicleId).ToList().Count;
            if (result < limit)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.VehicleImagesExceededTheUploadLimit);
        }
        private IResult CheckIfImageOfTheVehicle(short vehicleId)
        {
            var result = _vehicleImageDal.GetAll(img => img.VehicleId == vehicleId).ToList().Count;
            if (result > 0)
            {
                return null;
            }
            return new ErrorResult(Messages.ThereIsNotImageOfTheVehicle);
        }
    }
}
