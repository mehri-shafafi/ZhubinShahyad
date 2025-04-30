using Microsoft.EntityFrameworkCore;
using News.Domain.News.Models;
using News.Domain.News.Repositories;
using News.Infrastructure;

namespace News.Domain.News
{
    public class NewsReadRepository : INewsReadRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public NewsReadRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // News_Article
        public async Task<List<News_Article>> GetNewsArticleAllAsync()
        {
            return await _dbContext.news_Articles.Include(p => p.Id).ToListAsync();
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
        public async Task<List<News_Comment>> GetNewsCommentAllAsync()
        {
            return await _dbContext.news_Comments.Include(p => p.Content).ToListAsync();
        }
        public async Task<News_Comment> GetNewsCommentAsync(int id)
        {
            return await _dbContext.news_Comments.FirstOrDefaultAsync(p => p.Id == id);
        }





    }
}
