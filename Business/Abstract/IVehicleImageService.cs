using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleImageService
    {
        IResult Add(IFormFile file, VehicleImage vehicleImg);
        IResult Update(IFormFile file, VehicleImage vehicleImg);
        IResult Delete(VehicleImage vehicleImg);
        IDataResult<List<VehicleImage>> GetAll();
        IDataResult<VehicleImage> GetById(int vehicleImgId);
        IDataResult<List<VehicleImage>> GetImagesByCarId(short vehicleId);
    }
}
