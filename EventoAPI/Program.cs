using Evento.DOMAIN.Core.interfaces;
using Evento.DOMAIN.Infraestructure.Data;
using Evento.DOMAIN.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Get Connection String 
var connectionString = builder.Configuration.GetConnectionString("DevConnection");


// Add services to the container.
builder.Services.AddDbContext<EventManagementDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAttendeesRepository, AttendeesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
