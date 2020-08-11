using System.Collections.Generic;
using BLB.Api.Net.Interfaces;

namespace BLB.Api.Net.Hydrators
{
    public class CategoryDtoHydrator : IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category>
    {

        public Domain.Net.Models.Dto.Category Hydrate(Domain.Net.Models.Category obj)
        {
            return MapSingleObject(obj);
        }

        public ICollection<Domain.Net.Models.Dto.Category> HydrateList(ICollection<Domain.Net.Models.Category> obj)
        {
            ICollection<Domain.Net.Models.Dto.Category> result = new List<Domain.Net.Models.Dto.Category>();

            foreach (var rec in obj)
            {
                result.Add(MapSingleObject(rec));
            }

            return result;
        }

        private Domain.Net.Models.Dto.Category MapSingleObject(Domain.Net.Models.Category obj)
        {
            return new Domain.Net.Models.Dto.Category()
            {
                Id = obj.Id,
                Name = obj.Name,
                ParentCategoryId = obj.ParentCategoryId
            };
        }
    }
}
