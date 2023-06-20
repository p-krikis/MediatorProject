using MediatR;

namespace MediatorProject.Commands
{
    public class AuthenticateUserCommand : IRequest<string>
    {
        public string Email { get; }
        public string Password { get; }

        public AuthenticateUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
