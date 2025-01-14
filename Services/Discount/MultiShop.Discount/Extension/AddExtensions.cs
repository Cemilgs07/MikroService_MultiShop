using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Extension
{
    public static class AddExtensions
    {
        public static void AddServisExtensions(this IServiceCollection services)
        {
            services.AddTransient<IDiscountServices,DisCountServices>();
        }
    }
}
