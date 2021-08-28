using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        Task<IResult> AddAsync(Vehicle vehicle);
        Task<IResult> AddRangeAsync(IEnumerable<Vehicle> vehicles);
        IResult Update(Vehicle vehicle);
        IResult UpdateRange(IEnumerable<Vehicle> vehicles);
        IResult Remove(Vehicle vehicle);
        IResult RemoveRange(IEnumerable<Vehicle> vehicles);
        ValueTask<IDataResult<Vehicle>> GetByIdAsync(short vehicleId);
        IDataResult<Vehicle> GetById(short vehicleId);
        Task<IDataResult<IEnumerable<Vehicle>>> GetAllAsync();
        IDataResult<IEnumerable<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max);
        IDataResult<IEnumerable<VehicleDetailDto>> GetVehicleDetails();
    }
}
