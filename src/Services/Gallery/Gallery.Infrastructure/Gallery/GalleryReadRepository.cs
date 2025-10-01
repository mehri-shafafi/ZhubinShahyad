using Gallery.Domain.Dtos.Gallery;
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

        public async Task<List<GalleryDto>> FetchAllGalleryEntityAsync()
        {
            var resultDto = await _dbContext.Gallery
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .Select(p => new GalleryDto
                    {
                        Id = p.Id,
                        CategoriesGalleryId = p.CategoriesGalleryId, // <-- اینجا
                        Title_FA = p.Category.Title_FA,                        // <-- اینجا
                        Title_EN = p.Category.Title_EN,
                        Title_AR = p.Category.Title_AR,
                        ImageUrl = p.ImageUrl,
                        CreationDateTime = p.CreationDateTime,
                        CreationDateTimeShamsi = p.CreationDateTimeShamsi,
                        ModificationDateTime = p.ModificationDateTime,
                        ModificationDateTimeShamsi = p.ModificationDateTimeShamsi
                    })
                    .ToListAsync();

            return resultDto;
        }
        public async Task<GalleryDto> FetchGalleryEntityAsync(int id)
        {
            var gallery = await _dbContext.Gallery
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (gallery == null) return null;

            // Mapping به DTO
            var dto = new GalleryDto
            {
                Id = gallery.Id,
                ImageUrl = gallery.ImageUrl,
                CategoriesGalleryId = gallery.CategoriesGalleryId,
                Title_FA = gallery.Category != null ? gallery.Category.Title_FA : null,
                Title_EN = gallery.Category != null ? gallery.Category.Title_EN : null,
                Title_AR = gallery.Category != null ? gallery.Category.Title_AR : null
            };

            return dto;
        }


    }
}
