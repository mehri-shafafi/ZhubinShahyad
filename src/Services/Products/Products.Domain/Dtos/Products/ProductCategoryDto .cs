using Products.Domain.Base;

namespace Products.Domain.Dtos.Products;
public class ProductCategoryDto : BaseEntity
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }
    public string Description { get; set; }
    public string Permalink { get; set; }
    public bool Active { get; set; }
    public int Priority { get; set; }
    public string BannerUrl { get; set; }
    public string IconUrl { get; set; }
    public string ThumbnailUrl { get; set; }
}

