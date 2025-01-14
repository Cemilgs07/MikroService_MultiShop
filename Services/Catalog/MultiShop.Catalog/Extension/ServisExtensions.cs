using MultiShop.Catalog.Services.AboutService;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeaturesSLiderService;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageImageServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOftterService;

namespace MultiShop.Catalog.Extension
{
    public static class ServisExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IProductDetailService, ProdcutDetailService>();
            services.AddScoped<IProductImageImageService, ProductImageService>();
            services.AddScoped<IFeaturesSliderService, FeatureSliderServices>();
            services.AddScoped<ISpecialOffterService, SpecialOffterService>();
            services.AddScoped<IAboutService, AboutService>();

        }
    }
}
