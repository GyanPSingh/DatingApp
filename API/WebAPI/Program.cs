using Microsoft.AspNetCore.HttpsPolicy;
using WebAPI.Extensions;
using WebAPI.Middleware;
//using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServics(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseMiddleware<ExceptionMiddleware>();

//app.UseMiddleware<WebAPI.Middleware.ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();


app.Run();
