using System;

namespace BLB.Domain.Net.Models.Dto
{
    public class Product : BaseView
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Sku { get; set; }

        public DateTime? StockBackOrderEstimatedArrival { get; set; }

        public int? StockOnBackOrder { get; set; }

        public int? StockOnHand { get; set; }

    }
}
