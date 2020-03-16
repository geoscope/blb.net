using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string ExternalUserId { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string HashedVerificationCode { get; set; }

        public bool? IsUserLockedOut { get; set; }

        public bool? IsUserVerified { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }

        [ForeignKey("Store")]
        public long StoreId { get; set; }

        public ICollection<Address> UserAddresses { get; }

        public ICollection<UserInUserRole> UserInUserRoles { get; }

        public DateTime? UserLockedEndDate { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public ICollection<Order> UserOrders { get; }

        [Required]
        [StringLength(50)]
        public string UserSalt { get; set; }

        public ICollection<UserSetting> UserSettings { get; }
    }
}