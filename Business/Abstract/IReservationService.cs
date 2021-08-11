using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IReservationService
    {
        IResult Add(Reservation reservation);
        IResult Update(Reservation reservation);
        IResult Delete(Reservation reservation);
        IDataResult<List<Reservation>> GetAll();
    }
}
