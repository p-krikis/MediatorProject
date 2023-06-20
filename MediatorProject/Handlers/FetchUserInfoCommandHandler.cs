using MediatorProject.Commands;
using MediatorProject.Models;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class FetchUserInfoCommandHandler : IRequestHandler<FetchUserInfoCommand, List<UserInfoResponse>>
    {
        private readonly UserInfoService _userInfoService;

        public FetchUserInfoCommandHandler(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task<List<UserInfoResponse>> Handle(FetchUserInfoCommand command, CancellationToken cancellationToken)
        {
            return await _userInfoService.UserInfo(command.UserId);
        }
    }
}
