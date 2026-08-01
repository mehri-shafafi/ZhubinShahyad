using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Infrastructure.Products;

public class ProductWriteRepository : IProductWriteRepository
{
    private readonly ProductDbContext _dbContext;
    private readonly IMapper _mapper;
    public ProductWriteRepository(ProductDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    #region 
    public async Task<ProductCategoryModel> AddProductCategoriesAsync(ProductCategoryModel ProductCategory)
    {
        var entity = _mapper.Map<ProductCategory>(ProductCategory);
        var result = await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        var resultModel = _mapper.Map<ProductCategoryModel>(result.Entity);
        return resultModel;
    }
    public async Task<ProductCategoryModel?> UpdateProductCategoriesAsync(ProductCategoryModel productCategory)
    {
        var existing = await _dbContext.ProductCategories.FindAsync(productCategory.Id);
        if (existing == null) return null;

        _mapper.Map(productCategory, existing);

        await _dbContext.SaveChangesAsync();
        var resultDto = _mapper.Map<ProductCategoryModel>(existing);

        return resultDto;


    }


    public async Task DeleteProductCategoriesAsync(ProductCategoryModel ProductCategory)
    {
        var entity = await _dbContext.ProductCategories.FindAsync(ProductCategory.Id);
        if (entity == null)
            throw new Exception("ProductCategory not found");
        entity.Active = false;
        var result = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    #endregion
    #region 
    public async Task<ProductModel> AddProductAsync(ProductModel productEntity)
    {

        var entity = _mapper.Map<ProductEntity>(productEntity);


        await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProductModel>(entity);
    }
    public async Task<ProductModel> UpdateProductAsync(UpdateProductModel product)
    {

        var entity = await _dbContext.Products
            .Include(x => x.Images).
            FirstOrDefaultAsync(x => x.Id == product.ProductId);

        if (entity == null)
            throw new Exception("Product not found");

        _mapper.Map(product, entity);

        if (product.BrandId.HasValue)
            entity.BrandId = product.BrandId.Value;

        if (product.CategoryId.HasValue)
            entity.CategoryId = product.CategoryId.Value;

        // حذف تصاویر
        if (product.DeletedImageUrls.Any())
        {
            entity.Images
         .Where(x => product.DeletedImageUrls.Contains(x.ImageUrl))
         .ToList()
         .ForEach(x => x.IsActive = false);
        }

        // اضافه کردن تصاویر جدید
        foreach (var imageUrl in product.NewImageUrls)
        {
            entity.Images.Add(new ProductImages
            {
                ProductId = entity.Id,
                ImageUrl = imageUrl
            });
        }

        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ProductModel>(entity);
    }
    public async Task<UpdateProductImageModel> UpdateProductImageAsync(UpdateProductImageModel productImage)
    {

        var entity = await _dbContext.ProductImages.FirstOrDefaultAsync(x => x.Id == productImage.Id);

        if (entity == null)
            throw new Exception("Product not found");

        _mapper.Map(productImage, entity);

        if (productImage.ProductId.HasValue)
            entity.ProductId = productImage.ProductId.Value;


        await _dbContext.SaveChangesAsync();

        return _mapper.Map<UpdateProductImageModel>(entity);
    }
    public async Task DeleteProductImageAsync(UpdateProductImageModel productImage)
    {
        // اول از روی Id محصول رو از دیتابیس می‌گیریم
        var entity = await _dbContext.ProductImages
            .FirstOrDefaultAsync(p => p.Id == productImage.Id);

        if (entity != null)
        {
            if (productImage.ProductId.HasValue)
                entity.ProductId = productImage.ProductId.Value;

            entity.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }

    #endregion
    #region 
    public async Task<ProductBrandModel> AddBrandAsync(ProductBrandModel ProductBrand)
    {
        var entity = _mapper.Map<ProductBrand>(ProductBrand);
        var result = await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        var model = _mapper.Map<ProductBrandModel>(result.Entity);
        return model;
    }
    public async Task<ProductBrandModel> UpdateBrandAsync(ProductBrandModel ProductBrand)
    {
        var existing = await _dbContext.Brands.FindAsync(ProductBrand.Id);
        if (existing == null) return null;

        _mapper.Map(ProductBrand, existing);
        await _dbContext.SaveChangesAsync();
        var resultDto = _mapper.Map<ProductBrandModel>(existing);
        return resultDto;

    }

    public async Task DeleteBrandAsync(ProductBrandModel ProductBrand)
    {
        var brand = await _dbContext.Brands
            .FirstOrDefaultAsync(b => b.Id == ProductBrand.Id);

        if (brand == null)
            throw new KeyNotFoundException($"Brand with Id {ProductBrand.Id} not found.");

        _dbContext.Brands.Remove(brand);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {


        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (entity is null)
        {
            throw new Exception("News category not found");
        }
        entity.IsActive = false;
        var result = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
    #endregion

