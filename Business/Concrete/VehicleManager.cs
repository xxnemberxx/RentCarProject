using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        [CacheAspect]
        public IDataResult<IEnumerable<Vehicle>> GetByBetweenTwoUnitPrice(decimal min, decimal max)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Vehicle>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Vehicle>>
                (_vehicleDal.Find(v => v.PricePerHr >= min && v.PricePerHr <= max), Messages.SelectedList);
        }

        [CacheAspect]
        public IDataResult<IEnumerable<VehicleDetailDto>> GetVehicleDetails()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<VehicleDetailDto>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<VehicleDetailDto>>
                (_vehicleDal.GetVehicleDetails(),Messages.SelectedList);
        }

        [SecuredOperation("vehicle.update,admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Update(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _vehicleDal.Update(vehicle);
            _vehicleDal.SaveChanges();

            return new SuccessResult(Messages.Updated);
        }

        [SecuredOperation("vehicle.add, admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public async Task<IResult> AddAsync(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _vehicleDal.AddAsync(vehicle);
            await _vehicleDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("vehicle.add, admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public async Task<IResult> AddRangeAsync(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _vehicleDal.AddRangeAsync(vehicles);
            await _vehicleDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("vehicle.update, admin")]
        [ValidationAspect(typeof(VehicleValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult UpdateRange(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _vehicleDal.UpdateRange(vehicles);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("vehicle.remove, admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult Remove(Vehicle vehicle)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _vehicleDal.Remove(vehicle);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("vehicle.remove, admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IVehicleService.Get")]
        public IResult RemoveRange(IEnumerable<Vehicle> vehicles)
        {
            var result = BusinessRules.Run();
            if(!result.Success)
            {
                return result;
            }

            _vehicleDal.RemoveRange(vehicles);
            _vehicleDal.SaveChanges();

            return new SuccessResult();
        }

        [CacheAspect]
        public async ValueTask<IDataResult<Vehicle>> GetByIdAsync(short vehicleId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Vehicle>(result.Message);
            }

            return new SuccessDataResult<Vehicle>
                (await _vehicleDal.GetByIdAsync<short>(vehicleId));
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Vehicle>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Vehicle>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Vehicle>>
                (await _vehicleDal.GetAllAsync());
        }

        [CacheAspect]
        public IDataResult<Vehicle> GetById(short vehicleId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Vehicle>(result.Message);
            }

            return new SuccessDataResult<Vehicle>(_vehicleDal.GetById(vehicleId));
        }
    }
}
