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
        public async Task<List<News_CategoryModel>> GetNewsCategoryAllAsync()
        {

            var result = await _dbContext.news_Articles
              .Select(t => new News_CategoryModel
              {
                  Id = t.Id,
                  Name = t.Name,
                  Description = t.Description,
                  Slug = t.Slug,
                  CreatedDate = t.CreatedDate,
                  UpdatedDate = t.UpdatedDate,
              }).ToListAsync();



            return result;
        }
        public async Task<News_CategoryModel> GetNewsCategoryAsync(int id)
        {

            return await _dbContext.news_Categories.FirstOrDefaultAsync(p => p.Id == id)
                 .Select(t => new News_CategoryModel
                 {
                     Id = t.Id,
                     Name = t.Name,
                     Description = t.Description,
                     Slug = t.Slug,
                     CreatedDate = t.CreatedDate,
                     UpdatedDate = t.UpdatedDate,
                 }).ToListAsync();
        }

        // News_Comment
        public async Task<List<NewsArticleResDto>> GetNewsCommentAllAsync()
        {
            var result = await _dbContext.news_Articles
               .Select(t => new NewsArticleResDto
               {
                   Id = t.Id,
                   ImageURL = t.ImageURL,
                   Summary_EN = t.Summary_EN,
                   Title_EN = t.Title_EN,
                   Content_EN = t.Content_EN,
                   Summary_FA = t.Summary_FA,
                   Title_FA = t.Title_FA,
                   Content_FA = t.Content_FA,
                   Summary_AR = t.Summary_AR,
                   Title_AR = t.Title_AR,
                   Content_AR = t.Content_AR,
                   ViewsCount = t.ViewsCount,
                   CreationDateTime = t.CreationDateTime

               }).ToListAsync();

            return result;
            //return await _dbContext.news_Comments.Include(p => p.Content).ToListAsync();
        }





    }
}
