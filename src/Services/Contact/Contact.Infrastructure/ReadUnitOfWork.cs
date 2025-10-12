using AutoMapper;
using Contact.Domain.Menu;
using Contact.Domain.Repositories;
using Contact.Domain.UnitOfWork.Contact;

namespace Contact.Infrastructure;

public class ReadUnitOfWork : IReadUnitOfWork
{

    private readonly ContactDbContext _context;
    private IMapper _mapper;
    public ReadUnitOfWork(ContactDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    private ContactReadRepository _contactReadRepository;
    public IContactReadRepository ContactReadRepository
    {
        get
        {
            return _contactReadRepository ??= new ContactReadRepository(_context,_mapper);
        }
    }

}
