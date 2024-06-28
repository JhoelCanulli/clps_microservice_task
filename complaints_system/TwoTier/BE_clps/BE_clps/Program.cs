using BE_clps.Controllers;
using BE_clps.Models;
using BE_clps.Repositories;
using BE_clps.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;

namespace BE_clps
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Context>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<ComplainantRepository>();
            builder.Services.AddScoped<SubjctRepository>();

            //builder.Services.AddScoped<ComplainantService>();
            //builder.Services.AddScoped<SubjctService>();

            builder.Services.AddScoped<ComplainantController>();
            builder.Services.AddScoped<SubjctController>();

            var app = builder.Build();

            app.UseCors(builder =>
            builder
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

#if DEBUG
            app.UseCors(options =>
            {
                options
                    .WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
#endif

            app.MapControllers();

            app.Run();
        }
    }
}


