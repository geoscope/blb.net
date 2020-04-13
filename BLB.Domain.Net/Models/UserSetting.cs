using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class UserSetting : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }

        [StringLength(512)]
        public string Value { get; set; }
    }
}