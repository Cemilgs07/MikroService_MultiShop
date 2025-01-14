using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.Bussines.Concrete;
using MultiShop.Cargo.DataAccesLayer.Abstract;
using MultiShop.Cargo.DataAccesLayer.Concrete;
using MultiShop.Cargo.DataAccesLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CargoContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICargoCompanyDal,efCargoCompanyDal>();
builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoOperationDal,EfCargoOperationDal>();
builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();


builder.Services.AddScoped<ICargoCompanyservice, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
