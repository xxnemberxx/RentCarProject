using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IDto
    {
        public short BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
