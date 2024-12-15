using API.Extensions;
using FirstRestAPI.Application.Extensions;
using FirstRestAPI.Infrastructure;
using FirstRestAPI.Application;
using FirstRestAPI.Services;
using FirstRestAPI.Models;
using FirstRestAPI.Repositories;
using FirstRestAPI.Common;
using FirstRestAPI.Controllers;
using FirstRestAPI.Models.Base;
using FirstRestAPI.Interfaces;
using FirstRestAPI.InterfacesRepositories;
using FirstRestAPI.Common.Enums;


var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration["ConnectionStrings:Database"];

builder.Services.AddJwtTokenBearer();
builder.Services.AddSwaggerWithAuth();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddServices();


var app = builder.Build();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/employee/swagger.json", "EmployeeService API v1"));
app.UseAuthorization();
app.MapControllers();
app.UseDeveloperExceptionPage();
app.Run();