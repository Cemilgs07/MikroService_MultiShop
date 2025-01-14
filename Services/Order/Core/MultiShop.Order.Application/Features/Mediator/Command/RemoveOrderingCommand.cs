using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Command
{
    public class RemoveOrderingCommand:IRequest
    {
        public int Id;

        public RemoveOrderingCommand(int id)
        {
            Id = id;
        }
    }
}
