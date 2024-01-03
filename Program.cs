using Microsoft.EntityFrameworkCore;
using SteenBookKeepingSystem.Database.Context;
using SteenBookKeepingSystem.Services.Implementations;
using SteenBookKeepingSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookKeepingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookKeepingDatabase")));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});

// Optional: Add error handling middleware here

app.Run();
