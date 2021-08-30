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
    public class QuickUpdateSummeryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuickUpdateSummeryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("EndPoint - GET api/QUSummery");
            return Ok(await _mediator.Send(new GetAllQuickUpdateSummeryQuery { }));
        }
        [HttpGet("{appCode}")]
        public async Task<IActionResult> Get(string appCode)
        {
            Log.Information("EndPoint - GET api/QuickUpdateSummery/{appCode}");
            return Ok(await _mediator.Send(new GetAllQuickUpdateSummeryQuery { AppCode = appCode }));
        }

        [HttpGet("{appCode}/{userId}")]
        public async Task<IActionResult> Get( string appCode,Guid userId)
        {
            Log.Information("EndPoint - GET api/QuickUpdateSummery/{appCode}/{userId}");
            return Ok(await _mediator.Send(new GetAllQuickUpdateSummeryQuery { AppCode = appCode, UserId= userId }));
        }
    }
}
