using BLB.Domain.Net.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Order : BaseEntity
    {
        [StringLength(256)]
        public string Name { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("Address")]
        public long ShippingAddressId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
    }
}