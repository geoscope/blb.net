using System;
using System.Collections.Generic;
using BLB.Api.Net.Interfaces;

namespace BLB.Api.Net.Hydrators
{
    public class CategoryDtoHydrator : IGenericHydrator<Domain.Net.Models.Category, Domain.Net.Models.Dto.Category>
    {
        public CategoryDtoHydrator()
        {
        }

        public Domain.Net.Models.Dto.Category Hydrate(Domain.Net.Models.Category obj)
        {
            return new Domain.Net.Models.Dto.Category()
            {
                Name = obj.Name,
                ParentCategoryId = obj.ParentCategoryId
            };
        }

        public ICollection<Domain.Net.Models.Dto.Category> HydrateList(ICollection<Domain.Net.Models.Category> obj)
        {
            ICollection<Domain.Net.Models.Dto.Category> result = new List<Domain.Net.Models.Dto.Category>();

            foreach (var rec in obj)
            {
                result.Add(new Domain.Net.Models.Dto.Category()
                {
                    Name = rec.Name,
                    ParentCategoryId = rec.ParentCategoryId
                });
            }

            return result;
        }
    }
}
