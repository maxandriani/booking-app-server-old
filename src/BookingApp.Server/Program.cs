using BookingApp.Relational;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookingApp.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add low level configurations
builder.Services.AddDbContext<BookingAppDbContext>(options
  => options.UseNpgsql(builder.Configuration.GetConnectionString(BookingAppDbContext.ConnectionName)));

builder.Services.AddAutoMapper(typeof(BookingMapperProfile));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
