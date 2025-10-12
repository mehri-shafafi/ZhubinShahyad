using AutoMapper;
using Contact.Domain.Contact.Models;
using Contact.Domain.Repositories;
using Contact.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Contact.Domain.Menu
{
    public class ContactReadRepository : IContactReadRepository
    {
        private readonly ContactDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContactReadRepository(ContactDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> FetchAllContactEntityAsync()
        {
            var resultDto = await _dbContext.Contacts
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .Select(p => new ContactModel
                    {
                        Id = p.Id,
                        CategoryName = p.Name,
                        CategoryId = p.Id,
                        Email = p.Email,
                        Name = p.Name,
                        IsRead = p.IsRead,
                        Message = p.Message,
                        Subject = p.Subject,
                        CreationDateTime = p.CreationDateTime,
                        CreationDateTimeShamsi = p.CreationDateTimeShamsi,
                        ModificationDateTime = p.ModificationDateTime,
                        ModificationDateTimeShamsi = p.ModificationDateTimeShamsi
                    })
                    .ToListAsync();

            return resultDto;
        }
        public async Task<ContactModel> FetchContactEntityAsync(int id)
        {
            var result = await _dbContext.Contacts
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result == null) return null;

            return _mapper.Map<ContactModel>(result);
        }


    }
}
