using MediatorProject.Commands;
using MediatorProject.Models;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class ListLoadSingleCommandHandler : IRequestHandler<ListLoadSingleCommand, string>
    {
        private readonly ListInfoService _listInfoService;

        public ListLoadSingleCommandHandler(ListInfoService listInfoService)
        {
            _listInfoService = listInfoService;
        }

        public async Task<string> Handle(ListLoadSingleCommand command, CancellationToken cancellationToken)
        {
            return await _listInfoService.LoadSingleList(command.UserId, command.ListName);
        }
    }
}
