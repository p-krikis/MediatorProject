using MediatR;

namespace MediatorProject.Commands
{
    public class AuthenticateUserCommand :IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
