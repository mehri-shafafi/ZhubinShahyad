using Contact.Domain.Contact.Models;

namespace Contact.Domain.Repositories
{
    public interface IContactReadRepository
    {

        #region
        Task<List<ContactModel>> FetchAllContactEntityAsync();
        Task<ContactModel> FetchContactEntityAsync(int id);
        #endregion
    }
}
