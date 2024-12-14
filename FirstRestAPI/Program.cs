// using FirstRestAPI;
// using FirstRestAPI.Models.Base;
// using static PostController;
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
//
// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();
//
//
// app.Run();
// HttpContext context = new DefaultHttpContext();
// var response = context.Response;
// response.StatusCode = 404;
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.OpenApi.Models;
// // using Microsoft.AspNetCore.Authentication.JwtBearer;
// // using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using FirstRestAPI.Interfaces;
// using FirstRestAPI.Models.Base;
// using FirstRestAPI.Repositories;
// using FirstRestAPI.Services;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Hosting;
// // using ApplicationContext.Services;
//
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microblogging API", Version = "v1" });
//
//     // Add JWT Bearer auth to Swagger UI
//     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         Description = "JWT Authorization header using the Bearer scheme.",
//         Name = "Authorization",
//         In = ParameterLocation.Header,
//         Type = SecuritySchemeType.Http,
//         Scheme = "Bearer"
//     });
//
//     c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//         {
//             new OpenApiSecurityScheme {
//                 Reference = new OpenApiReference {
//                     Type = ReferenceType.SecurityScheme,
//                     Id = "Bearer"
//                 }
//             },
//              new string[] { }
//          }
//     });
// });
//
// // Add JWT Authentication (example)
// // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// //     .AddJwtBearer(options =>
// //     {
// //         options.TokenValidationParameters = new TokenValidationParameters
// //         {
// //             ValidateIssuer = true,
// //             ValidateAudience = true,
// //             ValidateLifetime = true,
// //             ValidateIssuerSigningKey = true,
// //             ValidIssuer = builder.Configuration["Jwt:Issuer"],
// //             ValidAudience = builder.Configuration["Jwt:Audience"],
// //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
// //         };
// //     });
//
// // Register your data access and services
//  builder.Services.AddSingleton<ApplicationContext>();
//  builder.Services.AddScoped<PostRepository>();
//  builder.Services.AddScoped<IPostServices, PostServices>();
//
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
//
// app.UseAuthentication();
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();


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
// if (builder.Environment.IsDevelopment())
// {
//     DotNetEnv.Env.Load("../.env");
// }
 var connectionString = builder.Configuration["ConnectionStrings:Database"];

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

app.Run();

