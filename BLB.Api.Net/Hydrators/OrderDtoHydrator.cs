using System.Collections.Generic;
using BLB.Api.Net.Interfaces;

namespace BLB.Api.Net.Hydrators
{
    public class OrderDtoHydrator : IGenericHydrator<Domain.Net.Models.Order, Domain.Net.Models.Dto.Order>
    {

        public Domain.Net.Models.Dto.Order Hydrate(Domain.Net.Models.Order obj)
        {
            return MapSingleObject(obj);
        }

        public ICollection<Domain.Net.Models.Dto.Order> HydrateList(ICollection<Domain.Net.Models.Order> obj)
        {
            ICollection<Domain.Net.Models.Dto.Order> result = new List<Domain.Net.Models.Dto.Order>();

            foreach (var rec in obj)
            {
                result.Add(MapSingleObject(rec));
            }

            return result;
        }

        private Domain.Net.Models.Dto.Order MapSingleObject(Domain.Net.Models.Order obj)
        {
            return new Domain.Net.Models.Dto.Order()
            {
                Id = obj.Id,
                Name = obj.Name,
                OrderStatus = obj.OrderStatus
                // TODO: order items, shipping address hydration
            };
        }
    }
}
