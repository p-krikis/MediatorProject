using MediatorProject.Models;
using MediatR;

namespace MediatorProject.Commands
{
    public class FetchUserInfoCommand : IRequest<List<UserInfoResponse>>
    {
        public string UserId { get; }

        public FetchUserInfoCommand(string userId)
        {
            UserId = userId;
        }
    }
}
