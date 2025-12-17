namespace BlazorApp.Dtos.Products
{
    public class ProductResDto : ProductDto
    {
        public bool hasError { get; set; }
        public string ErrorDesc { get; set; }
    }
}
