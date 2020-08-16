
namespace BLB.Domain.Net.Models.Dto
{
    public class OrderItem : BaseView
    {
        public Product ProductId { get; set; }

        public long? ProductOptionId { get; set; }

        public int Quantity { get; set; }
    }
}