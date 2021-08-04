﻿using CAMMS.Strategy.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetActionByIdQuery : IRequest<ActionDto>
    {
        public GetActionByIdQuery()
        {

        }

        public int Id { get; set; }
    }
}
