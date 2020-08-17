using System.Collections.Generic;
using BLB.Domain.Net.Models.Enums;

namespace BLB.Domain.Net.Models.Dto
{
    public class Order : BaseView
    {
        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Address ShippingAddressId { get; set; }
    }
}
