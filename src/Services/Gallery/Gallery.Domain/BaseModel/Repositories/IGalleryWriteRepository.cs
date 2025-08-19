using Gallery.Domain.Gallery.Models;

namespace Gallery.Domain.Repositories
{
    public interface IGalleryWriteRepository
    {


        #region 
        Task<GalleryEntity> AddGalleryAsync(GalleryEntity galleryEntity);
        Task<GalleryEntity> UpdateGalleryAsync(GalleryEntity galleryEntity);
        Task DeleteBrandAsync(GalleryEntity galleryEntity);
        #endregion

    }
}
