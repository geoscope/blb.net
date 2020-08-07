using BLB.Domain.Net.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLB.Domain.Net.Models
{
    public class ProductImage : BaseEntity
    {
        public int? Height { get; set; }

        public long ImageFileSize { get; set; }

        public ImageType ImageType { get; set; }

        [Required]
        [StringLength(256)]
        public string ProductImageUri { get; set; }

        public int SortOrder { get; set; }

        public int? Width { get; set; }
    }
}