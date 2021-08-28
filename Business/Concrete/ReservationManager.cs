using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Task<IResult> AddAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<Reservation> reservations)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IDataResult<Reservation>> GetByIdAsync(int reservationId)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<Reservation> reservations)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<Reservation> reservations)
        {
            throw new NotImplementedException();
        }
    }
}
