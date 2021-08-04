﻿using CAMMS.Strategy.Application.Command;
using CAMMS.Strategy.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace CAMMS.Strategy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActionController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("EndPoint - GET api/project");
            return Ok(await _mediator.Send(new GetAllActionsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
