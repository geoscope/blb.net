using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class OrderItem : BaseEntity
    {
        [Required]
        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }

        [ForeignKey("ProductOption")]
        public long? ProductOptionId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}