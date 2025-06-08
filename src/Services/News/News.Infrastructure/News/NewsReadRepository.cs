using Microsoft.EntityFrameworkCore;
using News.Domain.Dtos.News;
using News.Domain.News.Models;
using News.Domain.News.Repositories;
using News.Infrastructure;

namespace News.Domain.News
{
    public class NewsReadRepository : INewsReadRepository
    {
        private readonly NewsDbContext _dbContext;
        public NewsReadRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // News_Article
        public async Task<List<News_Article>> GetNewsArticleAllAsync()
        {
            return await _dbContext.news_Articles.ToListAsync();
        }
        public async Task<News_Article> GetNewsArticleAsync(int id)
        {
            return await _dbContext.news_Articles.FirstOrDefaultAsync(p => p.Id == id);
        }

        //News_Author
        public async Task<List<News_Author>> GetNewsAuthorAllAsync()
        {
            return await _dbContext.news_Authors.Include(p => p.Id).ToListAsync();
        }
        public async Task<News_Author> GetNewsAuthorAsync(int id)
        {
            return await _dbContext.news_Authors.FirstOrDefaultAsync(p => p.Id == id);

        }

        // News_Category
        public async Task<List<News_Category>> GetNewsCategoryAllAsync()
        {
            return await _dbContext.news_Categories.Include(p => p.Description).ToListAsync();
        }
        public async Task<News_Category> GetNewsCategoryAsync(int id)
        {
            return await _dbContext.news_Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        // News_Comment
        public async Task<List<NewsArticleResDto>> GetNewsCommentAllAsync()
        {
            var result = await _dbContext.news_Articles
               .Select(t => new NewsArticleResDto
               {
                   Id=t.Id,
                   ImageURL = t.ImageURL,
                   Summary = t.Summary,
                   Title = t.Title,
                   ViewsCount = t.ViewsCount,
                   Content = t.Content,
                   CreationDateTime = t.CreationDateTime

               }).ToListAsync();
            
            return result;
            //return await _dbContext.news_Comments.Include(p => p.Content).ToListAsync();
        }
     




    }
}
