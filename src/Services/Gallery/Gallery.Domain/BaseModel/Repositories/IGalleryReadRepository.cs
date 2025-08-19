using Gallery.Domain.Gallery.Models;

namespace Gallery.Domain.BaseProject.Repositories
{
    public interface IGalleryReadRepository
    {

        #region
        Task<List<GalleryEntity>> FetchAllGalleryEntityAsync();
        Task<GalleryEntity> FetchGalleryEntityAsync(int id);
        #endregion
    }
}
