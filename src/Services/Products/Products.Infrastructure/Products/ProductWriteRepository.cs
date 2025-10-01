using Microsoft.EntityFrameworkCore;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Infrastructure.Products
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductWriteRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region 
        public async Task<ProductCategoryModel> AddProductCategoriesAsync(ProductCategoryModel ProductCategory)
        {
            var result = await _dbContext.AddAsync(ProductCategory);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductCategoryModel?> UpdateProductCategoriesAsync(ProductCategoryModel productCategory)
        {
            var existing = await _dbContext.ProductCategories.FindAsync(productCategory.Id);
            if (existing == null) return null;

            var entry = _dbContext.Entry(existing);
            var properties = typeof(ProductCategoryModel).GetProperties();

            foreach (var prop in properties)
            {
                var newValue = prop.GetValue(productCategory);
                if (newValue != null)
                {
                    prop.SetValue(existing, newValue);
                }
            }

            await _dbContext.SaveChangesAsync();

            // خروجی map بشه به DTO
            return new ProductCategoryModel
            {
                Id = existing.Id,
                Name_FA = existing.Name_FA,
                Name_EN = existing.Name_EN,
                Name_AR = existing.Name_AR,
                Description = existing.Description,
                Permalink = existing.Permalink,
                Active = existing.Active,
                Priority = existing.Priority,
                BannerUrl = existing.BannerUrl,
                IconUrl = existing.IconUrl,
                ThumbnailUrl = existing.ThumbnailUrl
            };
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
            var result = await _dbContext.AddAsync(productEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductModel> UpdateProductAsync(ProductModel productEntity)
        {
            var result = _dbContext.Update(productEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteProductAsync(ProductModel productDto)
        {
            // اول از روی Id محصول رو از دیتابیس می‌گیریم
            var productEntity = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productDto.ProductId);

            if (productEntity != null)
            {
                _dbContext.Products.Remove(productEntity);
                await _dbContext.SaveChangesAsync();
            }
        }

        #endregion
        #region 
        public async Task<ProductBrandModel> AddBrandAsync(ProductBrandModel ProductBrand)
        {
            var result = await _dbContext.AddAsync(ProductBrand);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductBrandModel> UpdateBrandAsync(ProductBrandModel ProductBrand)
        {
            var result = _dbContext.Update(ProductBrand);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
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
        #endregion
    }
}
