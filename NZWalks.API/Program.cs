using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;
using NZWalks.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["NZWalks:ConnectionString"];

builder.Services.AddDbContext<NZWalksDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddScoped <IRegionRepository, RegionRepository> ();
builder.Services.AddScoped <IRegionService, RegionService> ();

builder.Services.AddAutoMapper(typeof(AutoMapping));

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
