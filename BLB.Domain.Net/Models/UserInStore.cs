using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class UserInStore
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Range(0, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        [ForeignKey("Store")]
        [Range(0, long.MaxValue)]
        public long StoreId { get; set; }
    }
}