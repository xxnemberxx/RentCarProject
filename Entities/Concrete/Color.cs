using Core.Entities;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public byte ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
