using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class UserInUserRole
    {
        [Required]
        [ForeignKey("User")]
        [Range(0, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        [ForeignKey("UserRole")]
        [Range(0, long.MaxValue)]
        public long UserRoleId { get; set; }
    }
}