
using AutoMapper;
using Contact.Domain.Repositories;
using Contact.Domain.UnitOfWork.Contact;
using Contact.Infrastructure.Contact;

namespace Contact.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private IContactWriteRepository _contactWriteRepository;
    private readonly ContactDbContext _context;
    private IMapper _mapper;
    public WriteUnitOfWork(ContactDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IContactWriteRepository ContactWriteRepository
    {
        get
        {
            return _contactWriteRepository ??= new ContactWriteRepository(_context,_mapper);
        }
    }
}
