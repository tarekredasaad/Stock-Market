using Microsoft.EntityFrameworkCore;
using Stock_Models.Interfaces;
using StockMarket.Data;
using StockMarket.Data.Repository;
using StockMarket.MyHub;
using System.Diagnostics;

//namespace StockMarket
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {

var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("MyPolicy", builder =>
//         builder
//        .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//    );

//});

builder.Services.AddControllers();
            // Lea      rn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
                            .LogTo(log => Debug.WriteLine(log),LogLevel.Information)
                            .EnableSensitiveDataLogging());

            builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.MapHub<OrderHub>("/OrderHub");
            app.MapHub<RandomNumber>("/RandomNumber");
            app.MapControllers();

            app.Run();
//        }
//    }
//}