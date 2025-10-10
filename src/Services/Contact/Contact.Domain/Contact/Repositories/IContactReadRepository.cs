using Contact.Domain.Dtos.Contact;

namespace Contact.Domain.Repositories
{
    public interface IGalleryReadRepository
    {

        #region
        Task<List<GalleryDto>> FetchAllGalleryEntityAsync();
        Task<GalleryDto> FetchGalleryEntityAsync(int id);
        #endregion
    }
}
