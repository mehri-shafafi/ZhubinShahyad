using AdminPanel.Models.Products.Base;

namespace AdminPanel.Models.Products.Models
{
    public class ProductImagesModel : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int SortOrder { get; set; }


    }
}
