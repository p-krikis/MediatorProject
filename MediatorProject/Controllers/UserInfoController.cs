using MediatorProject.Commands;
using MediatorProject.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserAuthentication([FromBody] UserParsingModels content)
        {
            var command = new AuthenticateUserCommand(content.Email, content.Password);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("fetchInfo")]
        public async Task<IActionResult> FetchUserInfo([FromBody] RequestData content)
        {
            var command = new FetchUserInfoCommand(content.userId);
            var userInfo = await _mediator.Send(command);
            return Ok(userInfo);
        }

        [HttpPut("updateInfo")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdatedInfo updInfo)
        {
            string fullInfo = JsonConvert.SerializeObject(updInfo);
            var command = new UpdateUserInfoCommand(updInfo.UserId, updInfo.Email, updInfo.Username, updInfo.DisplayName, updInfo.Role, fullInfo);
            await _mediator.Send(command);
            return Ok("Updated");
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] RequestData content)
        {
            var command = new DeleteUserCommand(content.userId);
            await _mediator.Send(command);
            return Ok("Deleted");
        }
    }
}
