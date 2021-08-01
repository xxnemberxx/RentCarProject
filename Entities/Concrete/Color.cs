using Core.Entities;

namespace Entities.Concrete
{
    public class Color : IDto
    {
        public byte ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
