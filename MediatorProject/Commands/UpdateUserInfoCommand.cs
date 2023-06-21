using MediatR;

namespace MediatorProject.Commands
{
    public class UpdateUserInfoCommand : IRequest<int>
    {
        public string UserId { get; }
        public string Email { get; }
        public string Username { get; }
        public string DisplayName { get; }
        public string Role { get; }
        public string Full { get; }

        public UpdateUserInfoCommand(string userId, string email, string username, string displayName, string role, string full)
        {
            UserId = userId;
            Email = email;
            Username = username;
            DisplayName = displayName;
            Role = role;
            Full = full;
        }
    }
}
