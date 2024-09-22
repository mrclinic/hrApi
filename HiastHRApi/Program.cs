using hiastHRApi.Repository;
using Microsoft.EntityFrameworkCore;
using hiastHRApi.Services;
using hiastHRApi.global;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HrmappContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddRepository(connectionString);
builder.Services.AddService(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();
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
