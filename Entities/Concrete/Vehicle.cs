using Core.Entities;

namespace Entities.Concrete
{
    public class Vehicle : IEntity
    {
        public short VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public decimal PricePerHr { get; set; }
        public decimal OfferPercent { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public short ModelId { get; set; }
        public byte ColorId { get; set; }
    }
}
