using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class ModelType : IDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
