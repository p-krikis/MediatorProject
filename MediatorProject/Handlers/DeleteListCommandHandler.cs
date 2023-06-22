using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class DeleteListCommandHandler : IRequestHandler<DeleteListCommand, Unit>
    {
        private readonly ListInfoService _listInfoService;

        public DeleteListCommandHandler(ListInfoService listInfoService)
        {
            _listInfoService = listInfoService;
        }

        public async Task<Unit> Handle(DeleteListCommand command, CancellationToken cancellationToken)
        {
            await _listInfoService.DeleteSpecificList(command.UserId, command.ListName);
            return Unit.Value;
        }
    }
}
