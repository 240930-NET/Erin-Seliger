using Microsoft.EntityFrameworkCore;
using Pinball.API.Data;
using Pinball.API.Repository;
using Pinball.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<PinballContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Pinball")));

builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddControllers();


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

app.MapControllers();

app.Run();

