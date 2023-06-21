using MediatorProject.Commands;
using MediatorProject.Services;
using MediatR;

namespace MediatorProject.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UserInfoService _userInfoService;

        public DeleteUserCommandHandler(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _userInfoService.DeleteUser(command.UserId);
            return Unit.Value;
        }
    }
}
