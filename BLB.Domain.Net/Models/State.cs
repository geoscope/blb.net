using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLB.Domain.Net.Models
{
    public class State
    {
        [ForeignKey("Country")]
        public long CountryId { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}