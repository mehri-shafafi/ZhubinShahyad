using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;

namespace Gallery.Domain.Repositories
{
    public interface IGalleryReadRepository
    {

        #region
        Task<List<GalleryDto>> FetchAllGalleryEntityAsync();
        Task<GalleryDto> FetchGalleryEntityAsync(int id);
        #endregion
    }
}
