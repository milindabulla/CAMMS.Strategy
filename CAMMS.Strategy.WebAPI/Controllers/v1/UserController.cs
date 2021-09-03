using CAMMS.Strategy.Application.Command;
using CAMMS.Strategy.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CAMMS.Strategy.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(AuthenticateUserCommand command)
        {
            Log.Information("EndPoint - POST api/User/Authenticate");
            return Ok(await mediator.Send(command));
        }
    }
}
