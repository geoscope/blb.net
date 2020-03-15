using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public class Category : NamedBaseEntity
    {
        [Range(1, long.MaxValue)]
        public long? CategoryOwnerId { get; set; }

        public ICollection<ProductInCategory> CategoryProducts { get; }

        [Range(1, long.MaxValue)]
        public long? ParentCategoryId { get; set; }
    }
}