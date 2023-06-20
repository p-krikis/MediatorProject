using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace MediatorProject.Handlers
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly UserInfoService _userInfoService;

        public AuthenticateUserCommandHandler(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task<string> Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            string jsonString = JsonConvert.SerializeObject(command);
            return await _userInfoService.AuthUser(jsonString);
        }
    }
}
