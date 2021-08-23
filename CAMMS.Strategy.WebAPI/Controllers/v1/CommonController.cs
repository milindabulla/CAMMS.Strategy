using CAMMS.Strategy.Application.Query.Parameter;
using CAMMS.Strategy.Application.Query.Setting;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMMS.Strategy.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommonController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetSettingByAppCode")]
        public async Task<IActionResult> GetSettingByAppCode([FromQuery] GetSettingByAppCodeQuery query)
        {
            Log.Information("EndPoint - GET api/GetSettingByAppCode");
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetAllParameter")]
        public async Task<IActionResult> GetAllParameter([FromQuery] GetAllParameterQuery query)
        {
            Log.Information("EndPoint - GET api/etAllParameter");
            return Ok(await _mediator.Send(query));
        }
    }
}
