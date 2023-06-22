using MediatR;

namespace MediatorProject.Commands
{
    public class DeleteListCommand : IRequest<Unit>
    {
        public string UserId { get; }
        public string ListName { get; }

        public DeleteListCommand(string userId, string listName)
        {
            UserId = userId;
            ListName = listName;
        }
    }
}
