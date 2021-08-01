using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }
        public IDataResult<Vehicle> GetById(short vehicleId)
        {
            return new SuccessDataResult<Vehicle>(
                _vehicleDal.Get(v => v.VehicleId == vehicleId),
                Message.Selected
                );
        }
        public IDataResult<List<Vehicle>> GetAll()
        {
            // Business Code
            return new SuccessDataResult<List<Vehicle>>(
                _vehicleDal.GetAll(), 
                Message.SelectedList
                );
        }

        public IDataResult<List<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max)
        {
            // Business Code
            return new SuccessDataResult<List<Vehicle>>(
                _vehicleDal.GetAll(v => v.PricePerHr >= min && v.PricePerHr <= max), 
                Message.SelectedList
                );
        }

        public IDataResult<List<VehicleDetailDto>> GetVehicleDetails()
        {
            // Business Code
            return new SuccessDataResult<List<VehicleDetailDto>>(
                _vehicleDal.GetVehicleDetails(), 
                Message.SelectedList
                );
        }
    }
}
