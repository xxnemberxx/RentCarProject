using Core.Entities;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public short ModelId { get; set; }
        public string ModelName { get; set; }
        public short BrandId { get; set; }
        public byte TypeId { get; set; }
    }
}
