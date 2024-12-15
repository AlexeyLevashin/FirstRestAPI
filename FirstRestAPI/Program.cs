using API.Extensions;
using FirstRestAPI.Application.Extensions;
using FirstRestAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.UseDeveloperExceptionPage();
app.Run();