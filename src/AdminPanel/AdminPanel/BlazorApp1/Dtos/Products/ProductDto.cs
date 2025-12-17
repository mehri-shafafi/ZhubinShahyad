namespace BlazorApp.Dtos.Products
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name_FA { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string? Description_FA { get; set; }
        public string? Description_EN { get; set; }
        public string? Description_AR { get; set; }
        public decimal Price { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public string SKU { get; set; }
        public string CatalogURL { get; set; }
        public string catalog_cover_image_url { get; set; }
        public string Warranty { get; set; }
        public int Rating { get; set; }
        public string BrandName { get; set; }
        public string CategoryName_FA { get; set; }
        public string CategoryName_EN { get; set; }
        public string CategoryName_AR { get; set; }
        public List<string> ImageUrls { get; set; }
        public string CatalogCoverImageUrl { get; set; }
        public DateTime CreationDateTime { get; set; } 
        public DateTime ModificationDateTime { get; set; } 
        public string CreationDateTimeShamsi { get; set; }
        public string ModificationDateTimeShamsi { get; set; }

    }
}
