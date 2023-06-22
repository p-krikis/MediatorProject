using MediatorProject.Commands;
using MediatorProject.Models;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class ListLoadAllCommandHandler : IRequestHandler<ListLoadAllCommand, List<ReturnType>>
    {
        private readonly ListInfoService _listInfoService;

        public ListLoadAllCommandHandler(ListInfoService listInfoService)
        {
            _listInfoService = listInfoService;
        }

        public async Task<List<ReturnType>> Handle(ListLoadAllCommand command, CancellationToken cancellationToken)
        {
            return await _listInfoService.LoadAllLists(command.UserId);
        }
    }
}
