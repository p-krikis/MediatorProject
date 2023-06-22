using MediatorProject.Models;
using MediatR;

namespace MediatorProject.Commands
{
    public class ListLoadSingleCommand : IRequest<string>
    {
        public string UserId { get; }
        public string ListName { get; }

        public ListLoadSingleCommand(string userId, string listName)
        {
            UserId = userId;
            ListName = listName;
        }
    }
}
