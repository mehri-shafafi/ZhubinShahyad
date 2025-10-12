using AutoMapper;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.UnitOfWork.Contact;
using MediatR;
namespace Contact.Application.Contact.Queries.GetContactList
{
    internal class GetBaseProjectListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactResDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetBaseProjectListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ContactResDto>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.ContactReadRepository.FetchAllContactEntityAsync();


            var resultDto = _mapper.Map<List<ContactResDto>>(result);
            return resultDto;
        }
    }
}
