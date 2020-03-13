namespace BLB.Domain.Net.Models.Dto
{
    public class Category : BaseView
    {
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }

    }
}
