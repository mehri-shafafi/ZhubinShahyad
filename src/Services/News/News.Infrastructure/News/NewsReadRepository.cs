using Microsoft.EntityFrameworkCore;
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
        public async Task<List<News_ArticleModel>> GetNewsArticleAllAsync()
        {
            return await _dbContext.news_Articles
               .AsNoTracking()
               .Include(p => p.news_Category)
               .Select(pc => new News_ArticleModel
               {
                   Id = pc.Id,
                   CategoryID = pc.CategoryID,
                   AuthorID = pc.AuthorID,
                   Content_AR = pc.Content_AR,
                   Content_EN = pc.Content_EN,
                   Content_FA = pc.Content_FA,
                   CreationDateTime = pc.CreationDateTime,
                   ImageURL = pc.ImageURL,
                   ModificationDateTime = pc.ModificationDateTime,
                   PublishedDate = pc.PublishedDate,
                   Summary_AR = pc.Summary_AR,
                   Summary_EN = pc.Summary_EN,
                   Summary_FA = pc.Summary_FA,
                   Tags = pc.Tags,
                   Title_AR = pc.Title_AR,
                   Title_EN = pc.Title_EN,
                   Title_FA = pc.Title_FA,
                   ViewsCount = pc.ViewsCount,
                   Active = pc.Active
               }).Where(pc=>pc.Active==true)
               .ToListAsync();


        }
        public async Task<News_ArticleModel?> GetNewsArticleAsync(int id)
        {

            return await _dbContext.news_Articles
                .AsNoTracking()
                .Include(a => a.news_Category)
                .Select(a => new News_ArticleModel
                {
                    Id=a.Id,
                    CategoryID = a.CategoryID,
                    AuthorID = a.AuthorID,
                    Content_AR = a.Content_AR,
                    Content_EN = a.Content_EN,
                    Content_FA = a.Content_FA,
                    CreationDateTime = a.CreationDateTime,
                    ImageURL = a.ImageURL,
                    ModificationDateTime = a.ModificationDateTime,
                    PublishedDate = a.PublishedDate,
                    Summary_AR = a.Summary_AR,
                    Summary_EN = a.Summary_EN,
                    Summary_FA = a.Summary_FA,
                    Tags = a.Tags,
                    Title_AR = a.Title_AR,
                    Title_EN = a.Title_EN,
                    Title_FA = a.Title_FA,
                    ViewsCount = a.ViewsCount
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        //News_Author
        public async Task<List<News_AuthorModel>> GetNewsAuthorAllAsync()
        {
            return await _dbContext.news_Authors
               .AsNoTracking()
               .Include(p => p.news_Articles)
               .Select(pc => new News_AuthorModel
               {
                   Id = pc.Id,
                   Bio=pc.Bio,
                   CreationDateTime=pc.CreationDateTime,
                   ModificationDateTime=pc.ModificationDateTime,
                   Name = pc.Name,
                   ProfilePictureURL=pc.ProfilePictureURL
               }).ToListAsync();
        }
        public async Task<News_AuthorModel> GetNewsAuthorAsync(int id)
        {
            return await _dbContext.news_Authors
                .Include(b=>b.news_Articles)
                .Where(b=>b.Id==id)
                .Select(pc=> new News_AuthorModel
                {
                    Id = pc.Id,
                    Bio = pc.Bio,
                    CreationDateTime = pc.CreationDateTime,
                    ModificationDateTime = pc.ModificationDateTime,
                    Name = pc.Name,
                    ProfilePictureURL = pc.ProfilePictureURL
                })
                .FirstOrDefaultAsync(p => p.Id == id);

        }

        // News_Category
        public async Task<List<News_CategoryModel>> GetNewsCategoryAllAsync()
        {

            var result = await _dbContext.news_Categories
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

            return await _dbContext.news_Categories
                 .Select(t => new News_CategoryModel
                 {
                     Id = t.Id,
                     Name = t.Name,
                     Description = t.Description,
                     Slug = t.Slug,
                     CreatedDate = t.CreatedDate,
                     UpdatedDate = t.UpdatedDate,
                 }).FirstOrDefaultAsync(p => p.Id == id);
        }

        // News_Comment
        public async Task<List<News_ArticleModel>> GetNewsCommentAllAsync()
        {
            var result = await _dbContext.news_Articles
               .Select(t => new News_ArticleModel
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
