using GreenDiamond.Application;
using GreenDiamond.Infrastructure;
using GreenDiamond.WebApi.Middleware;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddMemoryCache();
// Cache

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                  policy =>
                  {
                      policy.AllowAnyOrigin();
                      policy.AllowAnyMethod();
                      policy.AllowAnyHeader();
                  });
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.UseCors(MyAllowSpecificOrigins);

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.Run();
