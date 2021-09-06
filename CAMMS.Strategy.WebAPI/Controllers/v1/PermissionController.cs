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
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            this._mediator = mediator;
        }       

        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get(Guid UserId)
        {
            Log.Information("EndPoint - GET api/Permissio/UserId");
            return Ok(await _mediator.Send(new GetPermissionByUserIdQuery { UserId = UserId }));
        }       
    }
}
