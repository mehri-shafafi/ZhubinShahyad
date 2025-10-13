using AutoMapper;
using Contact.Application.Contact.Commands.Contact.UpdateContact;
using Contact.Application.Exception;
using Contact.Domain.UnitOfWork.Contact;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Gallery.Application.Gallery.Commands.Base.UpdateGallery;

public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCommandHandler> _logger;

    public UpdateCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var ModelRequest = await _readUnitOfWork.ContactReadRepository.FetchContactEntityAsync(request.Id);
        if (ModelRequest == null)
        {
            throw new NotFoundException(nameof(Base), request.Id);
        }
        // var updatedBase = _mapper.Map<Domain.Contact.Models.ContactEntity>(request);
       var result= await _writeUnitOfWork.ContactWriteRepository.UpdateContactAsync(ModelRequest);
        if (result)
        {
            _logger.LogInformation($"Base {ModelRequest.Id} is successfully created.");
        }
        return true;
    }
}