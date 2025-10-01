using Products.Domain.Base;

namespace Products.Domain.Products.Models
{
    public class ProductImagesModel : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int SortOrder { get; set; }


    }
}
