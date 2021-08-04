using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IResult Add(Vehicle vehicle);
        IResult Update(Vehicle vehicle);
        IResult Delete(Vehicle vehicle);
        IDataResult<Vehicle> GetById(short vehicleId);
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<List<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetails();
    }
}
