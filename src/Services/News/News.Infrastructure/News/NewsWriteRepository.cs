using News.Domain.News.Models;
using News.Domain.News.Repositories;

namespace News.Infrastructure.News
{
    public class NewsWriteRepository : INewsWriteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public NewsWriteRepository(ApplicationDbContext dbContext)
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
        public async Task<News_Author> AddNews_AuthorAsync(News_Author news_Author)
        {
            var result = await _dbContext.AddAsync(news_Author);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_Author> UpdateNews_ArticleAsync(News_Author news_Author)
        {
            var result = _dbContext.Update(news_Author);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_AuthorAsync(News_Author news_Author)
        {
            _dbContext.news_Authors.Remove(news_Author);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
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


        public async Task<News_Comment> AddNews_CommentAsync(News_Comment news_Comment)
        {
            var result = await _dbContext.AddAsync(news_Comment);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<News_Comment> UpdateNews_CommentAsync(News_Comment news_Comment)
        {
            var result = _dbContext.Update(news_Comment);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteNews_CommentAsync(int id)
        {
            var comment = await _dbContext.news_Comments.FindAsync(id);
            if (comment != null)
            {
                _dbContext.news_Comments.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
