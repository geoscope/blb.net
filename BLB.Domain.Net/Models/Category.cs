using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public class Category : NamedBaseEntity
    {
        [Range(1, long.MaxValue)]
        public long? CategoryOwnerId { get; set; }

        [Range(1, long.MaxValue)]
        public long? ParentCategoryId { get; set; }
    }
}