using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.Domain.News.Models;

namespace News.Domain.News.Repositories
{
    public interface INewsWriteRepository
    {
        #region
        Task<bool> AddNews_ArticleAsync(News_ArticleModel news_Article);
        Task<News_ArticleModel> UpdateNews_ArticleAsync(News_ArticleModel news_Article);
        Task DeleteNews_ArticleAsync(News_ArticleModel news_Article);
        #endregion
        #region
        Task<News_AuthorModel> AddNews_AuthorAsync(News_AuthorModel news_Author);
        Task<News_AuthorModel> UpdateNews_AuthorAsync(News_AuthorModel news_Author);
        Task DeleteNews_AuthorAsync(News_AuthorModel news_Author);
        #endregion
        #region
        Task<News_CategoryModel> AddNews_CategoryAsync(News_CategoryModel news_Category);
        Task<News_CategoryModel> UpdateNews_CategoryAsync(News_CategoryModel news_Category);
        Task DeleteNews_CategoryAsync(News_CategoryModel news_Category);
        #endregion
        #region
        #endregion
    }
}
