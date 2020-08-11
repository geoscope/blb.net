using System.Collections.Generic;
using BLB.Api.Net.Interfaces;

namespace BLB.Api.Net.Hydrators
{
    public class ProductDtoHydrator : IGenericHydrator<Domain.Net.Models.Product, Domain.Net.Models.Dto.Product>
    {

        public Domain.Net.Models.Dto.Product Hydrate(Domain.Net.Models.Product obj)
        {
            return MapSingleObject(obj);
        }

        public ICollection<Domain.Net.Models.Dto.Product> HydrateList(ICollection<Domain.Net.Models.Product> obj)
        {
            ICollection<Domain.Net.Models.Dto.Product> result = new List<Domain.Net.Models.Dto.Product>();

            foreach (var rec in obj)
            {
                result.Add(MapSingleObject(rec));
            }

            return result;
        }

        private Domain.Net.Models.Dto.Product MapSingleObject(Domain.Net.Models.Product obj)
        {
            return new Domain.Net.Models.Dto.Product()
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }
    }
}
