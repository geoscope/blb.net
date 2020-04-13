using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public abstract class CodeNamedBaseEntity : BaseEntity
    {
        [StringLength(3)]
        public string LongCode { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(2)]
        public string ShortCode { get; set; }
    }
}