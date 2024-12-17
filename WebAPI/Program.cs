using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using DotNetEnv;
using Infrastructure.Data;
using Infrastructure.Data.Seeders;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();
            var connectionString =
                $"Server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
                $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                $"User Id={Environment.GetEnvironmentVariable("DB_USER")};" +
                $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                $"Encrypt={Environment.GetEnvironmentVariable("DB_ENCRYPT")};" +
                $"TrustServerCertificate={Environment.GetEnvironmentVariable("DB_TRUST_SERVER_CERTIFICATE")};";

            //SQL SERVICE
            builder.Services.AddDbContext<KitePawnDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //AUTO MAPPER SERVICE
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Application services
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<IContractRepository, ContractRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IActionService, ActionService>();
            builder.Services.AddScoped<IActionsRepository, ActionsRepository>();

            //CONTROLLERS SERVICE
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*");
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}