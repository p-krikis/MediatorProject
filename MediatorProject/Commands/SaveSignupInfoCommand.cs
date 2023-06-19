using MediatR;

namespace MediatorProject.Commands
{
    public class SaveSignupInfoCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public string Role { get; set; }
    }
}
