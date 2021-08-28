using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public IDataResult<IEnumerable<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return new ErrorDataResult<IEnumerable<Vehicle>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Vehicle>>
                (_vehicleDal.Find(v => v.PricePerHr >= min && v.PricePerHr <= max), Messages.SelectedList);
        }

        public IDataResult<IEnumerable<VehicleDetailDto>> GetVehicleDetails()
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return new ErrorDataResult<IEnumerable<VehicleDetailDto>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<VehicleDetailDto>>
                (_vehicleDal.GetVehicleDetails(),Messages.SelectedList);
        }

        public IResult Update(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _vehicleDal.Update(vehicle);
            _vehicleDal.SaveChanges();

            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _vehicleDal.Remove(vehicle);
            _vehicleDal.SaveChanges();

            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("vehicle.add, admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        public async Task<IResult> AddAsync(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            await _vehicleDal.AddAsync(vehicle);
            await _vehicleDal.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> AddRangeAsync(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            await _vehicleDal.AddRangeAsync(vehicles);
            await _vehicleDal.SaveChangesAsync();

            return new SuccessResult();
        }

        public IResult UpdateRange(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _vehicleDal.UpdateRange(vehicles);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        public IResult Remove(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }

            _vehicleDal.Remove(vehicle);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        public IResult RemoveRange(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if(result != null)
            {
                return result;
            }

            _vehicleDal.RemoveRange(vehicles);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        public async ValueTask<IDataResult<Vehicle>> GetByIdAsync(short vehicleId)
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return new ErrorDataResult<Vehicle>(result.Message);
            }

            return new SuccessDataResult<Vehicle>
                (await _vehicleDal.GetByIdAsync<short>(vehicleId));
        }

        public async Task<IDataResult<IEnumerable<Vehicle>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (result != null)
            {
                return new ErrorDataResult<IEnumerable<Vehicle>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Vehicle>>
                (await _vehicleDal.GetAllAsync());
        }

        public IDataResult<Vehicle> GetById(short vehicleId)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.GetById<short>(vehicleId));
        }
    }
}
