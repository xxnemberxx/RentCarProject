using Core.Entities;

namespace Entities.Concrete
{
    public class VehicleImage : IEntity
    {
        public int VehicleImageId { get; set; }
        public short VehicleId { get; set; }
        public string ImgPath { get; set; }
        public string ImgName { get; set; }
        public string ImgExtension { get; set; }
        public long ImgSize { get; set; }
    }
}
