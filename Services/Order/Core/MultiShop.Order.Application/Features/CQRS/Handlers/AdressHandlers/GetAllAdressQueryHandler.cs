using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAllAdressQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAllAdressQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllAdressQueryResult>> Handle()
        {
             var values= await _repository.GetAllAsync();
                return values.Select(x=> new GetAllAdressQueryResult
                {
                    AdressId = x.AdressId,
                    City = x.City,
                    Detail=x.Detail,
                    District = x.District,
                    UserId=x.UserId,
                }).ToList();
        }
    }
}
