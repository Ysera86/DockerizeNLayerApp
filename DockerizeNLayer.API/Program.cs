using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DockerizeNLayer.API.Filters;
using DockerizeNLayer.API.Middlewares;
using DockerizeNLayer.API.Modules;
using DockerizeNLayer.Core.DTOs;
using DockerizeNLayer.Core.Repositories;
using DockerizeNLayer.Core.Services;
using DockerizeNLayer.Core.UnitOfWorks;
using DockerizeNLayer.Repository;
using DockerizeNLayer.Repository.Repositories;
using DockerizeNLayer.Repository.UnitOfWorks;
using DockerizeNLayer.Service.Mapper;
using DockerizeNLayer.Service.Services;
using DockerizeNLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
#region FluentValidation and Add Filter

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

//  Filtera kendi modelini g�nderme diyoruz. mvcde otomatik true ama api da set etmek gerekli.
builder.Services.Configure<ApiBehaviorOptions>(opt => opt.SuppressModelStateInvalidFilter = true);

#endregion



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Autofac ile RepoServiceModule i�inde dinamik olarak ekledik

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>(); 

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(MapProfile));

#endregion

#region Custom Filters

builder.Services.AddScoped(typeof(NotFoundFilter<>));

#endregion

#region Db ConnectionString

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
#endregion

#region Autofac : IoC(Inversion of control) container 

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

#endregion

#region Caching

builder.Services.AddMemoryCache();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// hata oldu�u i�in UseAuthorization ve MapControllers �st�nde olmal� , Httpe y�nlendirmesi yaps�n sora bu �al��s�n.
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
