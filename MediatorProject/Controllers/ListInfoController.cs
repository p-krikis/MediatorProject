using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
