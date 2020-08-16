namespace BLB.Domain.Net.Models.Dto
{
    public class Address : BaseEntity
    {
        public string City { get; set; }

        public Country Country { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }

        public State State { get; set; }
    }
}