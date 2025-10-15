using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using Products.Domain.Products.Repositories;

namespace Products.Infrastructure.Products
{
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

            _mapper.Map(productCategory ,existing);

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
            var result = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            var resModel = _mapper.Map<ProductModel>(result.Entity);
            return resModel;
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
            var entity = _mapper.Map<ProductBrand>(ProductBrand);
            var result = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            var model = _mapper.Map<ProductBrandModel>(result.Entity);
            return model;
        }
        public async Task<ProductBrandModel> UpdateBrandAsync(ProductBrandModel ProductBrand)
        {
            var existing = await _dbContext.Brands.FindAsync(ProductBrand.Id);
            if (existing == null)  return null;
           
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
        #endregion
    }
}
