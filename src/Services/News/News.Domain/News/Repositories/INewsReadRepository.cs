using News.Domain.Dtos.News;
using News.Domain.News.Models;

namespace News.Domain.News.Repositories
{
    public interface INewsReadRepository
    {
        #region
        Task<List<News_Article>> GetNewsArticleAllAsync();
        Task<News_Article> GetNewsArticleAsync(int id);
        #endregion
        #region
        Task<List<News_AuthorModel>> GetNewsAuthorAllAsync();
        Task<News_AuthorModel> GetNewsAuthorAsync(int id);
        #endregion
        #region
        Task<List<News_Category>> GetNewsCategoryAllAsync();
        Task<News_Category> GetNewsCategoryAsync(int id);
        #endregion
       
    }
}
