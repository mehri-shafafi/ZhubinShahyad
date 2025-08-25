using Gallery.Domain.Gallery.Models;
using Gallery.Domain.Repositories;
using Gallery.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Domain.Menu
{
    public class GalleryReadRepository : IGalleryReadRepository
    {
        private readonly GalleryDbContext _dbContext;
        public GalleryReadRepository(GalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GalleryEntity>> FetchAllGalleryEntityAsync()
        {
            return await _dbContext.Gallery.ToListAsync();
        }
        public async Task<GalleryEntity> FetchGalleryEntityAsync(int id)
        {
            return await _dbContext.Gallery.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
