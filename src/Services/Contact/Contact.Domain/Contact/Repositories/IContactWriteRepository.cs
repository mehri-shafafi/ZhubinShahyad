using Contact.Domain.Contact.Models;

namespace Contact.Domain.Repositories
{
    public interface IContactWriteRepository
    {


        #region 
        Task<bool> AddContactAsync(ContactModel ContactEntity);
        Task<bool> UpdateContactAsync(ContactModel ContactEntity);
        Task DeleteAsync(ContactModel ContactEntity);
        #endregion

    }
}
