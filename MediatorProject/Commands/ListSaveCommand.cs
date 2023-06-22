using MediatorProject.Models;
using MediatR;

namespace MediatorProject.Commands
{
    public class ListSaveCommand : IRequest<int>
    {
        public string ListName { get; }
        public string UserId { get; }
        public string Full { get; }

        public ListSaveCommand(string listName, string userId, string full)
        {
            ListName = listName;
            UserId = userId;
            Full = full;
        }
    }
}
