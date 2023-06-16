using MediatR;

namespace MediatorProject.Queries
{
    public class AuthenticateUserQuery : IRequest<string>
    {
        public string Email { get; set; }
    }
}
