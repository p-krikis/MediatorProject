using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class ListSaveCommandHandler : IRequestHandler<ListSaveCommand, int>
    {
        private readonly ListInfoService _listInfoService;

        public ListSaveCommandHandler(ListInfoService listInfoService)
        {
            _listInfoService = listInfoService;
        }

        public async Task<int> Handle(ListSaveCommand command, CancellationToken cancellationToken)
        {
            return await _listInfoService.SaveListData(command.UserId, command.ListName, command.Full);
        }
    }
}
