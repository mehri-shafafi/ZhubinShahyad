using AutoMapper;
using News.Domain.News.Entity;
using News.Domain.News.Models;
using News.Domain.News.Repositories;

namespace News.Infrastructure.News
{
    public class NewsWriteRepository : INewsWriteRepository
    {
        private readonly NewsDbContext _dbContext;
        private readonly IMapper _mapper;
        public NewsWriteRepository(NewsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #region 
        public async Task<News_ArticleModel> AddNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var entity = _mapper.Map<News_Article>(news_Article);
            var result = await _dbContext.AddAsync(news_Article);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_ArticleModel> UpdateNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var existing = await _dbContext.news_Articles.FindAsync(news_Article.Id);
            if (existing == null) return null;

            _mapper.Map(news_Article, existing);
            var result = _dbContext.Update(news_Article);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var entity = await _dbContext.news_Articles.FindAsync(news_Article.Id);
            if (entity == null)
                throw new Exception("ProductCategory not found");
            entity.Active = false;
            var result = _dbContext.Update(entity);
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
            var entity = await _dbContext.news_Authors.FindAsync(news_Author.Id);
            if (entity == null)
                throw new Exception("News category not found");
            entity.Active = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
      
        public async Task<News_CategoryModel> AddNews_CategoryAsync(News_CategoryModel news_Category)
        {
            var result = await _dbContext.AddAsync(news_Category);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<News_CategoryModel> UpdateNews_CategoryAsync(News_CategoryModel news_Category)
        {
            var result = _dbContext.Update(news_Category);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteNews_CategoryAsync(News_CategoryModel news_Category)
        {
            var entity = await _dbContext.news_Articles.FindAsync(news_Category.Id);
            if (entity == null)
                throw new Exception("News category not found");
            entity.Active = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

        }


    }
}
