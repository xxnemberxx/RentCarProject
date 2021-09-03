using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleImageService
    {
        Task<IResult> AddAsync(IFormFile file, VehicleImage vehicleImg);
        IResult Update(IFormFile file, VehicleImage vehicleImg);
        IResult Remove(VehicleImage vehicleImg);
        Task<IDataResult<IEnumerable<VehicleImage>>> GetAllAsync();
        IDataResult<VehicleImage> GetById(int imgId);       
        IDataResult<IEnumerable<VehicleImage>> GetImagesByCarId(short vehicleId);
    }
}
