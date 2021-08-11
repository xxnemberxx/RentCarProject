using Core.Entities;

namespace Entities.DTOs
{
    public class VehicleDetailDto : IDto
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string VehicleType { get; set; }
        public string ColorName { get; set; }
        public decimal PricePerHr { get; set; }
    }
}
