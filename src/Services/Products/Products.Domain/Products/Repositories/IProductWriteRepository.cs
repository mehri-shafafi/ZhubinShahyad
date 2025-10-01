using Products.Domain.Products.Models;

namespace Products.Domain.Products.Repositories
{
    public interface IProductWriteRepository
    {
        #region 
        Task<ProductCategoryModel> AddProductCategoriesAsync(ProductCategoryModel ProductCategory);
        Task<ProductCategoryModel> UpdateProductCategoriesAsync(ProductCategoryModel ProductCategory);
        Task DeleteProductCategoriesAsync(ProductCategoryModel ProductCategory);
        #endregion
        #region 
        Task<ProductModel> AddProductAsync(ProductModel productEntity);
        Task<ProductModel> UpdateProductAsync(ProductModel productEntity);
        Task DeleteProductAsync(ProductModel productEntity);

        #endregion
        #region 
        Task<ProductBrandModel> AddBrandAsync(ProductBrandModel ProductBrand);
        Task<ProductBrandModel> UpdateBrandAsync(ProductBrandModel ProductBrand);
        Task DeleteBrandAsync(ProductBrandModel ProductBrand);
        #endregion

    }
}
