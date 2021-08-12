using CAMMS.Strategy.Application.Command;
using CAMMS.Strategy.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CAMMS.Strategy.WebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActionController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllActionsQuery query )
        {
            Log.Information("EndPoint - GET api/project");
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Log.Information("EndPoint - GET api/project/id");
            return Ok(await _mediator.Send(new GetActionByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActionCommand command)
        {
            Log.Information("EndPoint - POST api/product");
            return Ok(await _mediator.Send(command));
        }
    }
}
