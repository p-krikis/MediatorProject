using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;
using System.Data.SqlClient;

namespace MediatorProject.Handlers
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, int>
    {
        private readonly UserInfoService _userInfoService;

        public UpdateUserInfoCommandHandler(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task<int> Handle(UpdateUserInfoCommand command, CancellationToken cancellationToken)
        {
            return await _userInfoService.UpdateUserInfo(command.UserId, command.Full);
        }
    }
}
