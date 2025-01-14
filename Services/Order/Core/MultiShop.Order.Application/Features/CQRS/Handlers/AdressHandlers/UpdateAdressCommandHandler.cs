using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public UpdateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAdressCommand updateAdressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAdressCommand.AdressId);
            values.UserId = updateAdressCommand.UserId;
            values.Detail = updateAdressCommand.Detail;
            values.District = updateAdressCommand.District;
            values.City = updateAdressCommand.City;
            values.UserId = updateAdressCommand.UserId;
            await _repository.GetUpdateAsync(values);

        }
    }
}
