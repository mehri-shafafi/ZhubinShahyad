using Contact.Domain.Contact.Models;

namespace Contact.Domain.Repositories
{
    public interface IContactWriteRepository
    {


        #region 
        Task<ContactModel> AddContactAsync(ContactModel ContactEntity);
        Task<ContactModel> UpdateContactAsync(ContactModel ContactEntity);
        Task DeleteAsync(ContactModel ContactEntity);
        #endregion

    }
}
