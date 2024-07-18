using InventoryService.Application.Commands;
using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure;
using InventoryService.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStockEntryRepository, StockEntryRepository>();

        services.AddMediatR(typeof(GetCategoryByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(SearchCategoriesQuery).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(CreateCategoryCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteCategoryCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateCategoryCommand).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(GetProductByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(SearchProductsQuery).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(CreateProductCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteProductCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateProductCommand).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(GetStockEntriesByProductIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateStockEntryCommand).GetTypeInfo().Assembly);

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Service API V1");
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
