using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;
using Newtonsoft.Json;

namespace MediatorProject.Handlers
{
    public class SaveSignupInfoCommandHandler : IRequestHandler<SaveSignupInfoCommand, int>
    {
        private readonly UserInfoService _userInfoService;

        public SaveSignupInfoCommandHandler(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task<int> Handle(SaveSignupInfoCommand command, CancellationToken cancellationToken)
        {
            string jsonString = JsonConvert.SerializeObject(command);
            return await _userInfoService.SaveUserInfo(jsonString);
        }
    }
}
