using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<Vehicle> GetById(short vehicleId);
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<List<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetails();
    }
}
