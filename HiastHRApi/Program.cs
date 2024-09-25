using hiastHRApi.Repository;
using Microsoft.EntityFrameworkCore;
using hiastHRApi.Services;
using hiastHRApi.global;
using System.Text.Json.Serialization;
using hiastHRApi.Helpers;
using Microsoft.OpenApi.Models;
using hiastHRApi.Shared.Common.Model;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => //add this to avoid circular json object
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // Enable CORS headers

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin() // <-- Allow any origin
                          .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
}); // Enable CORS headers

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HIAST HR API",
        Description = ".NET 8 Web API: HIAST HR API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
        "Example: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HrmappContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddRepository(connectionString);
builder.Services.AddService(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();
app.UseExceptionHandler();
app.UseMiddleware<JwtMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins); // Enable CORS headers
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
