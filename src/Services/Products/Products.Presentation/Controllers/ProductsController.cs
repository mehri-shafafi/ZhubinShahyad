using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Application.Products.Commands.Product.DeleteMedical;
using Products.Application.Products.Commands.Product.DeleteProductImage;
using Products.Application.Products.Commands.Product.UpdateProduct;
using Products.Application.Products.Commands.Product.UpdateProductImage;
using Products.Application.Products.Queries.Product.ById.GetProductsList;
using Products.Application.Products.Queries.Product.List.GetProductsList;
using Products.Presentation.Models;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;

namespace Products.Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// دریافت لیست محصولات
    [HttpGet("list")]
    [ProducesResponseType(typeof(List<ProductResponseDto<ProductDto>>), 200)]
    public async Task<ActionResult<List<ProductResponseDto<ProductDto>>>> GetListAsync()
    {
        var result = await _mediator.Send(new GetProductsListQuery());
        return Ok(result);
    }
    /// دریافت لیست محصول
    [HttpGet("getproductbyid")]
    [ProducesResponseType(typeof(ProductResponseDto<ProductDto>), 200)]
    public async Task<ActionResult<ProductResponseDto<ProductDto>>> GetProductByIdAsync([FromQuery] int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
        return Ok(result);
    }
    [HttpGet("productForClient")]
    //[ProducesResponseType(typeof(List<ProductResDto>), 200)]
    public async Task<ActionResult<List<ProductDetailsDto>>> GetProductForClientQuery()
    {

        var result = await _mediator.Send(new GetProductsForClientQuery());
        return Ok(result);
    }

    /// ایجاد محصول جدید
    [HttpPost("create")]
    [ProducesResponseType(typeof(ProductResponseDto<ProductDetailsDto>), 200)]
    public async Task<ActionResult<ProductResponseDto<ProductDetailsDto>>> CreateAsync([FromForm] CreateProductRequest request)
    {
        string? catalogUrl = null;
        string? catalogCoverImageUrl = null;
        var imageUrls = new List<string>();
        var imagePath = @"C:\Uploads\Products";

        if (request.CatalogUrl is not null)
        {
            catalogUrl =
           await SaveFileAndGetUrlAsync(request.CatalogUrl, "Catalogs", imagePath, "/root/media/Files/Catalogs");
        }

        if (request.CatalogCoverImageUrl is not null)
        {
            catalogCoverImageUrl =
           await SaveFileAndGetUrlAsync(request.CatalogCoverImageUrl, "Catalogs/Covers", imagePath, "/root/media/Files/Catalogs/Covers");
        }


        foreach (var image in request.Images)
        {

            var imageUrl = await SaveFileAndGetUrlAsync(
            image,
            "img/Products",
            imagePath, "/var/www/html/media/Files/img/Products");

            imageUrls.Add(imageUrl);

        }
        var command = new CreateProductCommand
        {
            Name_FA = request.Name_FA,
            Name_EN = request.Name_EN,
            Name_AR = request.Name_AR,
            Description_FA = request.Description_FA,
            Description_EN = request.Description_EN,
            Description_AR = request.Description_AR,
            Price = request.Price,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
            StockQuantity = request.StockQuantity,
            SKU = request.SKU,
            Warranty = request.Warranty,
            Rating = request.Rating,
            CatalogUrl = catalogUrl,
            CatalogCoverImageUrl = catalogCoverImageUrl,

            ImageUrls = imageUrls
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    private static async Task<string> SaveFileAndGetUrlAsync(
                                                                IFormFile file,
                                                                string folderName,
                                                                string uploadPath,
                                                                string fileBaseUrl)

    {

        Directory.CreateDirectory(uploadPath);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var filePath = Path.Combine(uploadPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);


        Console.WriteLine($"Saing file to: {filePath}");
        return $"{fileBaseUrl}/media/Files/{folderName}/{fileName}";

    }

    [HttpPut("update")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateAsync(
        [FromForm] UpdateProductRequest request)
    {
        string? catalogUrl = null;
        string? catalogCoverImageUrl = null;

        var newImageUrls = new List<string>();

        var imagePath = @"C:\Uploads\Products";

        // کاتالوگ جدید
        if (request.CatalogUrl != null)
        {
            catalogUrl = await SaveFileAndGetUrlAsync(
                request.CatalogUrl,
                "Catalogs",
                imagePath,
                "/root/media/Files/Catalogs");
        }

        // کاور جدید
        if (request.CatalogCoverImageUrl != null)
        {
            catalogCoverImageUrl = await SaveFileAndGetUrlAsync(
                request.CatalogCoverImageUrl,
                "Catalogs/Covers",
                imagePath,
                "/root/media/Files/Catalogs/Covers");
        }

        // تصاویر جدید
        if (request.Images != null && request.Images.Any())
        {
            foreach (var image in request.Images)
            {
                var imageUrl = await SaveFileAndGetUrlAsync(
                    image,
                    "img/Products",
                    imagePath,
                    "/var/www/html/media/Files/img/Products");

                newImageUrls.Add(imageUrl);
            }
        }

        var command = new UpdateProductCommand
        {
            ProductId = request.ProductId,

            Name_FA = request.Name_FA,
            Name_EN = request.Name_EN,
            Name_AR = request.Name_AR,

            Description_FA = request.Description_FA,
            Description_EN = request.Description_EN,
            Description_AR = request.Description_AR,

            Price = request.Price,

            BrandId = request.BrandId,
            CategoryId = request.CategoryId,

            StockQuantity = request.StockQuantity,

            SKU = request.SKU,

            Warranty = request.Warranty,

            Rating = request.Rating,

            // اگر فایل جدید ارسال نشده باشد null می‌ماند
            CatalogUrl = catalogUrl,
            CatalogCoverImageUrl = catalogCoverImageUrl,

            // تصاویر جدید
            NewImageUrls = newImageUrls,

            // تصاویر حذف شده
            DeletedImageUrls = request.DeletedImageUrls ?? new List<string>()
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    ///// ویرایش محصول
    //[HttpPut("update")]
    //[ProducesResponseType(typeof(bool), 200)]
    //[ProducesResponseType(400)]
    //public async Task<ActionResult<bool>> UpdateAsync(int id, [FromBody] UpdateProductCommand request)
    //{
    //    if (id != request.ProductId)
    //        return BadRequest("Id in route and body must match");

    //    var result = await _mediator.Send(request);
    //    return Ok(result);
    //}

    /// حذف محصول
    [HttpDelete("delete")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteAsync(int id)
    {
        var request = new DeleteProductCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// ویرایش عکس محصول
    [HttpPut("UpdateProductImageAsync/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateProductImageAsync(int id, [FromBody] UpdateProductImageCommand request)
    {
        if (id != request.Id)
            return BadRequest("Id in route and body must match");

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// حذف عکس محصول
    [HttpDelete("deleteproductimage/{id:int}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<ActionResult<bool>> DeleteProductImageAsync(int id)
    {
        var request = new DeleteProductImageCommand { Id = id };
        var result = await _mediator.Send(request);
        return Ok(result);
    }

}
