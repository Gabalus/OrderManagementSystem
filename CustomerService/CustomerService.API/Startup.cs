using CustomerService.Infrastructure;
using CustomerService.Infrastructure.Repositories;
using CustomerService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using CustomerService.Application.Queries;
using CustomerService.Application.Commands;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddMediatR(typeof(GetCustomerByIdQuery).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(SearchCustomersQuery).GetTypeInfo().Assembly);

        services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteCustomerCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);

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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Service API V1");
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
