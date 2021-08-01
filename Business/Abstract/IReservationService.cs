using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<List<Reservation>> GetAll();
    }
}
