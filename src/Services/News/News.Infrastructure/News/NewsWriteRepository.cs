using News.Domain.News.Models;
using News.Domain.News.Repositories;

namespace News.Infrastructure.News
{
    public class NewsWriteRepository : INewsWriteRepository
    {
        private readonly NewsDbContext _dbContext;
        public NewsWriteRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region 
        public async Task<News_Article> AddNews_ArticleAsync(News_Article news_Article)
        {
            var result = await _dbContext.AddAsync(news_Article);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_Article> UpdateNews_ArticleAsync(News_Article news_Article)
        {
            var result = _dbContext.Update(news_Article);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_ArticleAsync(News_Article news_Article)
        {
            _dbContext.news_Articles.Remove(news_Article);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
        public async Task<News_AuthorModel> AddNews_AuthorAsync(News_AuthorModel news_Author)
        {
            var result = await _dbContext.AddAsync(news_Author);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_AuthorModel> UpdateNews_AuthorAsync(News_AuthorModel news_Author)
        {
            var result = _dbContext.Update(news_Author);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_AuthorAsync(News_AuthorModel news_Author)
        {
            _dbContext.news_Authors.Remove(news_Author);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
      
        public async Task<News_Category> AddNews_CategoryAsync(News_Category news_Category)
        {
            var result = await _dbContext.AddAsync(news_Category);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_Category> UpdateNews_CategoryAsync(News_Category news_Category)
        {
            var result = _dbContext.Update(news_Category);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_CategoryAsync(News_Category news_Category)
        {
            _dbContext.news_Categories.Remove(news_Category);
            await _dbContext.SaveChangesAsync();
        }


    }
}
