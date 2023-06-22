using MediatorProject.Models;
using MediatR;

namespace MediatorProject.Commands
{
    public class ListLoadAllCommand : IRequest<List<ReturnType>>
    {
        public string UserId { get; }

        public ListLoadAllCommand(string userId)
        {
            UserId = userId;
        }
    }
}
