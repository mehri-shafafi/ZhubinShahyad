using AutoMapper;
using Contact.Domain.Contact.Models;
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

            var resultDto = new List<ContactResDto>();

            foreach (var item in result)
            {
                var dto = new ContactResDto
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    Email = item.Email,
                    Name = item.Name,
                    IsRead = item.IsRead,
                    Message = item.Message,
                    Subject = item.Subject,
                    CreationDateTime = item.CreationDateTime,
                    CreationDateTimeShamsi = item.CreationDateTimeShamsi,
                    ModificationDateTime = item.ModificationDateTime,
                    ModificationDateTimeShamsi = item.ModificationDateTimeShamsi,
                    Phone = item.Phone // اگر داری
                };

                resultDto.Add(dto);
            }

            return resultDto;

        }
    }
}
