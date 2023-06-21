using MediatR;

namespace MediatorProject.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public string UserId { get; }

        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }
    }
}
