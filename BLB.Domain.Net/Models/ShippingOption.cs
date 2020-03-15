using BLB.Domain.Net.Models.Enum;

namespace BLB.Domain.Net.Models
{
    public class ShippingOption : NamedBaseEntity
    {
        public ShippingDestination AllowedShippingDestination { get; set; }

        public ShippingCalculationType ShippingCalculation { get; set; }

        public long? ShippingCity { get; set; }

        public long? ShippingCountry { get; set; }

        public long? ShippingState { get; set; }
    }
}