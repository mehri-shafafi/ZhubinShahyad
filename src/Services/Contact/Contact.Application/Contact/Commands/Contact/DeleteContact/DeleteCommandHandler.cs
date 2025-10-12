using Contact.Domain.UnitOfWork.Contact;
using Contact.Application.Exception;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Contact.Commands.Base.DeleteContact;



public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteCommandHandler> _logger;

    public DeleteCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.ContactReadRepository.FetchContactEntityAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException("Base", request.Id);
        }

        await _writeUnitOfWork.ContactWriteRepository.DeleteAsync(result);

        return true;


    }
}

