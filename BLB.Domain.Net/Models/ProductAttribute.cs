using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class ProductAttribute : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        [StringLength(512)]
        public string Value { get; set; }
    }
}