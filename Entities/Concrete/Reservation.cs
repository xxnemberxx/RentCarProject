using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Reservation : IDto
    {
        public int ReservationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public short VehicleId { get; set; }
        public int CustomerId { get; set; }

    }
}
