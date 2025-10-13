using AutoMapper;
using Contact.Domain.Contact.Models;
using Contact.Domain.Repositories;

namespace Contact.Infrastructure.Contact
{
    public class ContactWriteRepository : IContactWriteRepository
    {
        private readonly ContactDbContext _dbContext;
        private IMapper _mapper;
        public ContactWriteRepository(ContactDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region 
        public async Task<bool> AddContactAsync(ContactModel input)
        {
            var model = _mapper.Map<ContactEntity>(input);

            try
            {
                var result = await _dbContext.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateContactAsync(ContactModel input)
        {

            var model = _mapper.Map<ContactEntity>(input);

            try
            {
                var result =  _dbContext.Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

                 }
        public async Task DeleteAsync(ContactModel input)
        {
            _dbContext.Remove(input);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

    }
}
