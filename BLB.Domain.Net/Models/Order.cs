using BLB.Domain.Net.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class Order : BaseEntity
    {
        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("Address")]
        public long ShippingAddressId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        //TODO: Shipping will be handled via a plugin

        //TODO: Payment options will be handled via a plugin
    }
}