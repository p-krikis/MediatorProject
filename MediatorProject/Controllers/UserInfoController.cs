using MediatorProject.Commands;
using MediatorProject.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SaveSignupInfo([FromBody] UserParsingModels content)
        {
            var command = new SaveSignupInfoCommand
            {
                Username = content.Username,
                Email = content.Email,
                Password = content.Password,
                UserId = content.UserId,
                DisplayName = content.DisplayName,
                Role = content.Role
            };

            var userId = await _mediator.Send(command);
            return Ok();
        }
    }
}
