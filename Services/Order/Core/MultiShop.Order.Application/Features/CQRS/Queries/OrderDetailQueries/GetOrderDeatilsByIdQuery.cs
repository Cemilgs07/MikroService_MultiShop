using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDeatilsByIdQuery
    {
        public int Id;

        public GetOrderDeatilsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
