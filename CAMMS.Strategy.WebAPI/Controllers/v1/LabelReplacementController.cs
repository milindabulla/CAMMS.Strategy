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
    public class LabelReplacementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LabelReplacementController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("EndPoint - GET api/LabelReplacement");
            return Ok(await _mediator.Send(new GetAllLabelReplacementQuery()));
        }
       
    }
}
