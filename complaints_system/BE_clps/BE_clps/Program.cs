using BE_clps.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PersonaggioRepo>();
builder.Services.AddScoped<SquadraRepo>();
builder.Services.AddScoped<PersonaggioService>();
builder.Services.AddScoped<SquadraService>();
builder.Services.AddScoped<PersonaggioController>();
builder.Services.AddScoped<SquadraController>();

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

app.MapControllers();

app.Run();
