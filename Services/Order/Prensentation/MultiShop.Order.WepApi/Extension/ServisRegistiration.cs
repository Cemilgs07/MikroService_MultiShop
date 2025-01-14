using MediatR;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.Mediator.Handler.OrderingHandler;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Repositories;

namespace MultiShop.Order.WepApi.Extension
{
    public static class ServisRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<GetAdressQueryHandler>();
            services.AddScoped<GetByIdQueryHandler>();
            services.AddScoped<CreateAdressCommandHandler>();
            services.AddScoped<RemoveAdressCommandHandler>();
            services.AddScoped<UpdateAdressCommandHandler>();

            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetByIdOrderDetailQueryHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();

            services.AddScoped(typeof(IRepository<>), typeof(Repositories<>));
            services.AddMediatR(typeof(CreateOrderingCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateOrderingCommandHandler).Assembly);
            services.AddMediatR(typeof(RemoveOrderingCommandHandler).Assembly);
            services.AddMediatR(typeof(GetOrderingQueryHandler).Assembly);
            services.AddMediatR(typeof(GetByIdOrderingCommanHandler).Assembly);



            services.AddMediatR(typeof(ServisRegistiration).Assembly);
        }
    }
}
