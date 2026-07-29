using AutoMapper;
using News.Domain.News.Entity;
using News.Domain.News.Models;
using News.Domain.News.Repositories;
using System.Text.RegularExpressions;

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
        public async Task<bool> AddNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var entity = _mapper.Map<News_Article>(news_Article);
            try
            {
            var result = await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                // بررسی خطای داخلی
                if (ex.InnerException != null && ex.InnerException.Message.Contains("FOREIGN KEY"))
                {
                    throw new Exception("کلید خارجی معتبر نیست، رکورد مرجع وجود ندارد.");
                }

                // سایر خطاها
                throw new Exception("ثبت خبر انجام نشد. جزئیات: " + ex.Message);
            }



        }
        public async Task<News_ArticleModel> UpdateNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var existing = await _dbContext.news_Articles.FindAsync(news_Article.Id);
            if (existing == null) return null;

            news_Article.CategoryID = news_Article.CategoryID != 0 ? news_Article.CategoryID : existing.CategoryID;
            news_Article.AuthorID = news_Article.AuthorID != 0 ? news_Article.AuthorID : existing.AuthorID;



            _mapper.Map(news_Article, existing);

            await _dbContext.SaveChangesAsync();
            var resultModel = _mapper.Map<News_ArticleModel>(existing);

            return resultModel;
        }
        public async Task DeleteNews_ArticleAsync(News_ArticleModel news_Article)
        {
            var entity = await _dbContext.news_Articles.FindAsync(news_Article.Id);
            if (entity == null)
                throw new Exception("ProductCategory not found");
            entity.IsActive = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region 
        public async Task<bool> AddNews_AuthorAsync(News_AuthorModel news_Author)
        {
            var entity = _mapper.Map<News_Author>(news_Author);
            try
            {
                var result = await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // بررسی خطای داخلی
                if (ex.InnerException != null && ex.InnerException.Message.Contains("FOREIGN KEY"))
                {
                    throw new Exception("کلید خارجی معتبر نیست، رکورد مرجع وجود ندارد.");
                }

                // سایر خطاها
                throw new Exception("ثبت خبر انجام نشد. جزئیات: " + ex.Message);
            }
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
            entity.IsActive = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
      
        public async Task<bool> AddNews_CategoryAsync(News_CategoryModel news_Category)
        {
            var entity = _mapper.Map<News_Category>(news_Category);
            try
            {
                var result = await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // بررسی خطای داخلی
                if (ex.InnerException != null && ex.InnerException.Message.Contains("FOREIGN KEY"))
                {
                    throw new Exception("کلید خارجی معتبر نیست، رکورد مرجع وجود ندارد.");
                }

                // سایر خطاها
                throw new Exception("ثبت دسته بندی انجام نشد. جزئیات: " + ex.Message);
            }


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
            entity.IsActive = false;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

        }
       public async Task<bool> ChangeStatusAsync(ChangeNewsArticleStatusModel input)
        {
            var entity = await _dbContext.news_Articles.FindAsync(input.Id);
            if (entity == null)
                throw new Exception("News category not found");
            entity.IsActive=input.IsActive;
            var result = _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }





    }
}
