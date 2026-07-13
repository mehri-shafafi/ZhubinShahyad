
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;

namespace Products.Domain.Products.Repositories
{
    public interface IProductReadRepository
    {
        #region
        Task<List<ProductCategoryModel>> FetchAllProductCategoryAsync();
        Task<ProductCategoryModel> FetchProductCategoryAsync(int id);
        #endregion
        #region
        Task<List<ProductBrandModel>> FetchAllProductBrandAsync();
        Task<ProductBrandModel> FetchProductBrandAsync(int id);
        #endregion
        #region
        Task<List<ProductModel>> FetchAllProductEntityAsync();
        Task<ProductModel> FetchProductEntityAsync(int id);
        // Task<ProductEntity> FetchProductAsync(int id);
        // Task<ProductEntity> FetchProductAsyncNoTracking(int id);
        Task<ProductModel> GetAsyncNoTracking(int id);
        Task<UpdateProductImageModel> GetProductImageByIdAsync(int id);
        #endregion
    }
}
