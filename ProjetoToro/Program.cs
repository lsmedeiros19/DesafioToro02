using Services.Interfaces;
using Services;
using Data.Interfaces;
using Data.Repository;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserPositionService, UserPositionService>()
.AddScoped<IUserPositionsRepository, UserPositionsRepository>()
.AddDbContextFactory<DatabaseContext>(options => options.UseInMemoryDatabase("position"));

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

//app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.DocumentTitle = "Projeto Toro";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Toro v1");
}
);


app.Run();
