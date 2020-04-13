using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public abstract class NamedBaseEntity : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string Code { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}