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
        public async Task<ProductCategory> AddProductCategoriesAsync(ProductCategory ProductCategory)
        {
            var result = await _dbContext.AddAsync(ProductCategory);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductCategory?> UpdateProductCategoriesAsync(ProductCategory productCategory)
        {
            var existing = await _dbContext.ProductCategory.FindAsync(productCategory.Id);
            if (existing == null) return null;

            var entry = _dbContext.Entry(existing);
            var properties = typeof(ProductCategory).GetProperties();

            foreach (var prop in properties)
            {
                var newValue = prop.GetValue(productCategory);
                if (newValue != null)
                {
                    prop.SetValue(existing, newValue);
                }
            }

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteProductCategoriesAsync(ProductCategory ProductCategory)
        {
            var entity = await _dbContext.ProductCategory.FindAsync(ProductCategory.Id);
            if (entity == null)
                throw new Exception("ProductCategory not found");
            entity.Active = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
        public async Task<ProductEntity> AddProductAsync(ProductEntity productEntity)
        {
            var result = await _dbContext.AddAsync(productEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductEntity> UpdateProductAsync(ProductEntity productEntity)
        {
            var result = _dbContext.Update(productEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteProductAsync(ProductEntity productEntity)
        {
            _dbContext.Products.Remove(productEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
        public async Task<ProductBrand> AddBrandAsync(ProductBrand ProductBrand)
        {
            var result = await _dbContext.AddAsync(ProductBrand);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ProductBrand> UpdateBrandAsync(ProductBrand ProductBrand)
        {
            var result = _dbContext.Update(ProductBrand);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteBrandAsync(ProductBrand ProductBrand)
        {
            _dbContext.Brands.Remove(ProductBrand);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
