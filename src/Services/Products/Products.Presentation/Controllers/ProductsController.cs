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
using Products.Infrastructure.Services.Storage;
using Products.Presentation.Models;

namespace Products.Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public readonly IMapper _mapper;
    private readonly IFileStorageService _fileStorageService;

    private const string BaseUrl = "https://zhubinshahyad.com";
    private const string ProductImagesPath = "/var/www/html/media/FilesStaging/img/Products";
    private const string ProductCatalogsPath = "/var/www/html/media/FilesStaging/Products";

    public ProductsController(IMediator mediator, IMapper mapper, IFileStorageService fileStorageService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
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
        ProductDto? product = null;

        var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
        product = result.Data;


        var fileUrl = product?.ImageUrls?
            .OrderBy(x => x.SortOrder)
            .FirstOrDefault()?.ImageUrl
            ?? product?.CatalogURL
            ?? product?.CatalogCoverImageUrl;

        var folderName = _fileStorageService.ExtractProductFolder(fileUrl);

        result.Data.FolderName = folderName ?? "";
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

        var folderName = request.FolderName ?? "Unknown";


        if (request.CatalogUrl is not null)
        {
            catalogUrl = await _fileStorageService.SaveFileAndGetUrlAsync(request.CatalogUrl, "Catalogs", Path.Combine(
                                                                                                "/var/www/html/media/FilesStaging/Products",
                                                                                                folderName));
        }

        if (request.CatalogCoverImageUrl is not null)
        {
            catalogCoverImageUrl =
           await _fileStorageService.SaveFileAndGetUrlAsync(request.CatalogCoverImageUrl, "Covers", Path.Combine("/var/www/html/media/FilesStaging/Products",
                                                                                                                folderName, "Catalogs"));
        }

        var imageDtos = new List<ProductImageDto>();

        for (int i = 0; i < request.Images.Count; i++)
        {
            var image = request.Images[i];

            var imageUrl = await _fileStorageService.SaveFileAndGetUrlAsync(
           image,
           folderName,
           "/var/www/html/media/FilesStaging/img/Products");

            imageDtos.Add(new ProductImageDto
            {
                ImageUrl = imageUrl,
                SortOrder = i+1
            });
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

            ImageUrls = imageDtos
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }



    [HttpPut("update")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<bool>> UpdateAsync(
        [FromForm] UpdateProductRequest request)
    {
        string? catalogCoverImageUrl = null;
        string? catalogUrl = null;

        var newImages = new List<ProductImageDto>();


        var productResult = await _mediator.Send(
                                         new GetProductByIdQuery
                                         {
                                             ProductId = request.ProductId
                                         });

        var product = productResult.Data;
        if (product is null)
        {
            return NotFound("محصول یافت نشد.");
        }

        var existingImageUrl = product?.ImageUrls?
                                        .FirstOrDefault()?
                                        .ImageUrl;
        var folderName = _fileStorageService.ExtractProductFolder(existingImageUrl);

        if (string.IsNullOrWhiteSpace(folderName))
        {
            return BadRequest("پوشه تصاویر محصول مشخص نیست.");
        }


        // کاتالوگ جدید
        if (request.CatalogUrl != null)
        {
            catalogUrl = await _fileStorageService.SaveFileAndGetUrlAsync(
                request.CatalogUrl,
                "Catalogs",
                "/var/www/html/media/FilesStaging/Catalogs");
        }

        // کاور جدید
        if (request.CatalogCoverImageUrl != null)
        {
            catalogCoverImageUrl = await _fileStorageService.SaveFileAndGetUrlAsync(
                request.CatalogCoverImageUrl,
                "Catalogs/Covers",
                "/var/www/html/media/FilesStaging/Catalogs/Covers");
        }


      
            // تصاویر جدید
            if (request.Images != null && request.Images.Any())
            {

                foreach (var image in request.Images)
                {
                    var imageUrl = await _fileStorageService.SaveFileAndGetUrlAsync(
                        image.Image,
                        folderName,
                        "/var/www/html/media/FilesStaging/img/Products");

                    newImages.Add(new ProductImageDto
                    {
                        ImageUrl = imageUrl,
                        SortOrder = image.SortOrder
                    });
                }
            }

            var existingImages = request.ExistingImages?
                .Select(x => new ProductImageDto
                {
                    ImageUrl = x.ImageUrl,
                    SortOrder = x.SortOrder
                })
                .ToList()
                ?? [];

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
                ExistingImages = existingImages,
                // تصاویر جدید
                NewImages = newImages,
                // تصاویر حذف شده
                DeletedImageUrls = request.DeletedImageUrls ?? new List<string>()
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        
    }


    /// حذف محصول
    [HttpDelete("{id}")]
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