using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        Task<IResult> AddAsync(Reservation reservation);
        Task<IResult> AddRangeAsync(IEnumerable<Reservation> reservations);
        IResult Update(Reservation reservation);
        IResult UpdateRange(IEnumerable<Reservation> reservations);
        IResult Remove(Reservation reservation);
        IResult RemoveRange(IEnumerable<Reservation> reservations);
        ValueTask<IDataResult<Reservation>> GetByIdAsync(int reservationId);
        Task<IDataResult<IEnumerable<Reservation>>> GetAllAsync();
    }
}
