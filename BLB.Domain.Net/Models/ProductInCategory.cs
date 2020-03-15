using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class ProductInCategory
    {
        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
    }
}