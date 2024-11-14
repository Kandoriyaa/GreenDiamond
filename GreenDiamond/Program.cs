using GreenDiamond.Application;
using GreenDiamond.Infrastructure;
using GreenDiamond.WebApi.Middleware;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add application services
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);

// Add caching services
builder.Services.AddMemoryCache();

// CORS policy
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

// No authentication configuration
// Just remove or comment out the authentication setup

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Authorization middleware should be used if authorization metadata is present
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Upload/Clothe")),
    RequestPath = new PathString("/Upload/Clothe"),
});

app.MapControllers();

app.Run();
