using Business.Abstract;
using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        public IDataResult<List<Reservation>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
