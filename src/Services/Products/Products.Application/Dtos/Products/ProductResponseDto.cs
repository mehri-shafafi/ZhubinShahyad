using Azure;

namespace Products.Application.Dtos.Products;

public class ProductResponseDto<TResponse> where TResponse : class
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public long StatusCode { get; set; }
    public string StatusDesc { get; set; }
    public TResponse Data { get; set; }
}
