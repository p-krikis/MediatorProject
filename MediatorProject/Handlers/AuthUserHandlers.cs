using MediatorProject.Commands;
using MediatR;

namespace MediatorProject.Handlers
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        public Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
