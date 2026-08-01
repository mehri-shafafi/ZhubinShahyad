using Microsoft.EntityFrameworkCore;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Infrastructure.Products;

public class ProductReadRepository : IProductReadRepository
{
    private readonly ProductDbContext _dbContext;
    public ProductReadRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductCategoryModel>> FetchAllProductCategoryAsync()
    {
        return await _dbContext.ProductCategories
            .AsNoTracking()
            .Include(p => p.Products)
            .Select(pc => new ProductCategoryModel
            {
                Id = pc.Id,
                Name_FA = pc.Name_FA,
                Name_EN = pc.Name_EN,
                Name_AR = pc.Name_AR,
                Description = pc.Description,
                Permalink = pc.Permalink,
                Active = pc.Active,
                Priority = pc.Priority,
                BannerUrl = pc.BannerUrl,
                IconUrl = pc.IconUrl,
                ThumbnailUrl = pc.ThumbnailUrl,
            })
            .ToListAsync();
    }
    public async Task<ProductCategoryModel?> FetchProductCategoryAsync(int id)
    {
        return await _dbContext.ProductCategories
            .AsNoTracking()
            .Include(p => p.Products)
            .Where(pc => pc.Id == id)
            .Select(pc => new ProductCategoryModel
            {
                Id = pc.Id,
                Name_FA = pc.Name_FA,
                Name_EN = pc.Name_EN,
                Name_AR = pc.Name_AR,
                Description = pc.Description,
                Permalink = pc.Permalink,
                Active = pc.Active,
                Priority = pc.Priority,
                BannerUrl = pc.BannerUrl,
                IconUrl = pc.IconUrl,
                ThumbnailUrl = pc.ThumbnailUrl,

            })
            .FirstOrDefaultAsync();
    }
    public async Task<List<ProductBrandModel>> FetchAllProductBrandAsync()
    {
        return await _dbContext.Brands
            .Include(b => b.Products) // چون Products navigation هست
            .Select(b => new ProductBrandModel
            {
                Id = b.Id,
                Name = b.Name,
                LogoURL = b.LogoURL,
                Description = b.Description,
                Products = b.Products.Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name_FA = p.Name_FA,
                    Name_EN = p.Name_EN,
                    Name_AR = p.Name_AR
                }).ToList()
            })
            .ToListAsync();
    }
    public async Task<ProductBrandModel?> FetchProductBrandAsync(int id)
    {
        return await _dbContext.Brands
            .Include(b => b.Products)
            .Where(b => b.Id == id)
            .Select(b => new ProductBrandModel
            {
                Id = b.Id,
                Name = b.Name,
                LogoURL = b.LogoURL,
                Description = b.Description,
                Products = b.Products.Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name_FA = p.Name_FA,
                    Name_EN = p.Name_EN,
                    Name_AR = p.Name_AR
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }
    public async Task<List<ProductModel>> FetchAllProductEntityAsync()
    {
        //var result = await _dbContext.Products.ToListAsync();
        var resultDto = await _dbContext.Products
           .AsNoTracking()
           .Include(p => p.ProductBrand)
           .Include(p => p.Category)
           .Include(p => p.Images)
           .Where(p=>p.IsActive==true)
           .Select(p => new ProductModel
           {
               ProductId = p.Id,
               Name_FA = p.Name_FA,
               Name_EN = p.Name_EN,
               Name_AR = p.Name_AR,
               Description_FA = p.Description_FA,
               Description_EN = p.Description_EN,
               Description_AR = p.Description_AR,
               Price = p.Price,

               BrandId = p.BrandId,

               CategoryId = p.CategoryId,
               StockQuantity = p.StockQuantity, // یا تبدیل به int اگر در Entity رشته است
               SKU = p.SKU,

               ImageUrls = p.Images.Select(i => i.ImageUrl).ToList(),

               CatalogURL = p.CatalogURL,
               CatalogCoverImageUrl = p.catalog_cover_image_url,
               Warranty = p.Warranty,
               Rating = p.Rating
           })
           .ToListAsync();

        return resultDto;
    }
    public async Task<ProductModel> FetchProductEntityAsync(int id)
    {
        var p = await _dbContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (p == null) return null;

        return new ProductModel
        {
            Id=p.Id,
            ProductId = p.Id,
            Name_FA = p.Name_FA,
            Name_EN = p.Name_EN,
            Name_AR = p.Name_AR,
            Description_FA = p.Description_FA,
            Description_EN = p.Description_EN,
            Description_AR = p.Description_AR,
            Price = p.Price,
            BrandId = p.BrandId,
            CategoryId = p.CategoryId,
            StockQuantity = p.StockQuantity,
            SKU = p.SKU,
            ImageUrls = p.Images.Select(i => i.ImageUrl).ToList(),
            CatalogURL = p.CatalogURL,
            CatalogCoverImageUrl = p.catalog_cover_image_url,
            Warranty = p.Warranty,
            Rating = p.Rating,
            IsActive=p.IsActive,
            ModificationDateTimeShamsi = p.ModificationDateTimeShamsi,
            CreationDateTimeShamsi = p.CreationDateTimeShamsi,
            CreationDateTime=p.CreationDateTime,
            ModificationDateTime = p.ModificationDateTime
        };
    }

    public async Task<ProductModel> GetAsyncNoTracking(int id)
    {
        var p = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return new ProductModel
        {
            ProductId = p.Id,
            Name_FA = p.Name_FA,
            Name_EN = p.Name_EN,
            Name_AR = p.Name_AR,
            Description_FA = p.Description_FA,
            Description_EN = p.Description_EN,
            Description_AR = p.Description_AR,
            Price = p.Price,
            BrandId = p.BrandId,
            CategoryId = p.CategoryId,
            StockQuantity = p.StockQuantity,
            SKU = p.SKU,
            ImageUrls = p.Images.Select(i => i.ImageUrl).ToList(),
            CatalogURL = p.CatalogURL,
            CatalogCoverImageUrl = p.catalog_cover_image_url,
            Warranty = p.Warranty,
            Rating = p.Rating
        };
    }

    public async Task<UpdateProductImageModel> GetProductImageByIdAsync(int id)
    {

        var result = await _dbContext.ProductImages.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        return new UpdateProductImageModel
        {
            Id = id,
            ImageUrl = result?.ImageUrl,
            ProductId = result?.ProductId,
            SortOrder = result?.SortOrder
        };

    }
}
