using MediatR;
using System;

namespace CAMMS.Strategy.Application.Command
{
    public class CreateActionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
