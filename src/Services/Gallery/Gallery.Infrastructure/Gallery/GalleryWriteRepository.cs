using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;
using Gallery.Domain.Repositories;

namespace Gallery.Infrastructure.Gallery
{
    public class GalleryWriteRepository : IGalleryWriteRepository
    {
        private readonly GalleryDbContext _dbContext;
        public GalleryWriteRepository(GalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region 
        public async Task<GalleryEntity> AddGalleryAsync(GalleryEntity galleryEntity)
        {
            var result = await _dbContext.AddAsync(galleryEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<GalleryEntity> UpdateGalleryAsync(GalleryEntity galleryEntity)
        {
            var result = _dbContext.Update(galleryEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteAsync(GalleryDto galleryEntity)
        {
            _dbContext.Remove(galleryEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

    }
}
