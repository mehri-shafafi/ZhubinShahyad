using AutoMapper;
using Contact.Application.Contact.Commands.Base.CreateContact;
using Contact.Domain.Contact.Models;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.UnitOfWork.Contact;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Contact.Application.Gallery.Commands.Base.CreateMedical;

public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCommandHandler> _logger;


    public CreateCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var modelRequest = new ContactModel
        {IsRead = request.IsRead,
        Message = request.Message,
        Name = request.Name,
        Email = request.Email,
        CategoryId = request.CategoryId,
         Subject = request.Subject,
         Phone=request.Phone
        };

        var result = await _writeUnitOfWork.ContactWriteRepository.AddContactAsync(modelRequest);
        if (result)
        {
        _logger.LogInformation($"Base {modelRequest.Email} is successfully created.");
        }

        //await _publishEndPoint.Publish(addBaseEvent);
        return result;
    }
}