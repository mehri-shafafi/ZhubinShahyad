namespace Products.Domain.Products.Models;

public class UpdateProductImageModel
{
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public string? ImageUrl { get; set; }
    public int? SortOrder { get; set; }

}