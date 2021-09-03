using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        [SecuredOperation("reservation.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public async Task<IResult> AddAsync(Reservation reservation)
        {
            var result = BusinessRules.Run();
            if(!result.Success)
            {
                return result;
            }

            await _reservationDal.AddAsync(reservation);
            await _reservationDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("reservation.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public async Task<IResult> AddRangeAsync(IEnumerable<Reservation> reservations)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _reservationDal.AddRangeAsync(reservations);
            await _reservationDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Reservation>>(result.Message);                 
            }

            return new SuccessDataResult<IEnumerable<Reservation>>
                (await _reservationDal.GetAllAsync());
        }

        [CacheAspect]
        public async ValueTask<IDataResult<Reservation>> GetByIdAsync(int reservationId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Reservation>(result.Message);
            }

            return new SuccessDataResult<Reservation>
                (await _reservationDal.GetByIdAsync<int>(reservationId));
        }

        [SecuredOperation("reservation.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public IResult Remove(Reservation reservation)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _reservationDal.Remove(reservation);
            _reservationDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("reservation.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public IResult RemoveRange(IEnumerable<Reservation> reservations)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _reservationDal.RemoveRange(reservations);
            _reservationDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("reservation.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public IResult Update(Reservation reservation)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _reservationDal.Update(reservation);
            _reservationDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("reservation.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReservationService.Get")]
        public IResult UpdateRange(IEnumerable<Reservation> reservations)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _reservationDal.UpdateRange(reservations);
            _reservationDal.SaveChanges();

            return new SuccessResult();
        }
    }
}
