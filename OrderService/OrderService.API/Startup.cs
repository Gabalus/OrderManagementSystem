using OrderService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OrderService.Domain.Interfaces;
using OrderService.Infrastructure.Repositories;
using InventoryService.Infrastructure.Repositories;
using InventoryService.Domain.Interfaces;
using OrderService.Application.Queries;
using System.Reflection;
using OrderService.Application.Commands;
using InventoryService.Infrastructure;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("OrderConnection")));

        services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("InventoryConnection")));

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddMediatR(typeof(GetOrderByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(SearchOrdersQuery).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(AddItemToOrderCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CancelOrderCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(ConfirmOrderPaymentCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateOrderCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteOrderCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeliverOrderCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateOrderCommand).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(Startup));


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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service API V1");
        });


        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
