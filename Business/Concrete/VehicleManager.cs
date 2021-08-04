using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
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

        public IResult Add(Vehicle vehicle)
        {
            ValidationTool.Validate(new VehicleValidator(), vehicle);
            _vehicleDal.Add(vehicle);
            return new SuccessResult(Message.Added);
        }

        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Message.Updated);
        }

        public IResult Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            return new SuccessResult(Message.Deleted);
        }
    }
}
