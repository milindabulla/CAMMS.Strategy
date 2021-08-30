using CAMMS.Strategy.Application.Query;
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
    public class SettingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettingController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("EndPoint - GET api/Setting");
            return Ok(await _mediator.Send(new GetSettingByAppCodeQuery()));
        }

        [HttpGet("{appCode}")]
        public async Task<IActionResult> GetAll(string appCode)
        {
            Log.Information("EndPoint - GET api/Setting/AppCode");
            return Ok(await _mediator.Send(new GetSettingByAppCodeQuery { ApplicationCode = appCode }));
        }
    }
}
