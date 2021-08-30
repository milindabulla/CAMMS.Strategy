using CAMMS.Strategy.Application.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CAMMS.Strategy.Application.Command
{
    public class CreateActionCommand : IRequest<int>,IAuthorizedRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [FromHeader(Name = "Authorization")]
        public string Token { get; set; }
    }
}
