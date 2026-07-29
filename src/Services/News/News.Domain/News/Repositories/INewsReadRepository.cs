using News.Domain.News.Models;

namespace News.Domain.News.Repositories
{
    public interface INewsReadRepository
    {
        #region
        Task<List<News_ArticleModel>> GetNewsArticleAllAsync();
        Task<News_ArticleModel?> GetNewsArticleAsync(int id);
        #endregion
        #region
        Task<List<News_AuthorModel>> GetNewsAuthorAllAsync();
        Task<News_AuthorModel?> GetNewsAuthorAsync(int id);
        #endregion
        #region
        Task<List<News_CategoryModel>> GetNewsCategoryAllAsync();
        Task<News_CategoryModel?> GetNewsCategoryAsync(int id);
        #endregion

    }
}
