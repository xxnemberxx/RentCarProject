using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public short BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
