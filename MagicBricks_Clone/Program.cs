using MagicBricks.Applications;
using MagicBricks.Applications.DTOs.DTOMapping;
using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Infrastructure;
using MagicBricks.Infrastructure.Context;
using MagicBricks.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conStr"));
});


//Added configuration for serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));



//Add Application Layer Extension Method
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddScoped<IAuthenticationRepository, UserAuthenticationRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

//Add Infrastructure Layer Extension Method
builder.Services.AddInfrastructureLayer(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Enable Serilog
app.UseSerilogRequestLogging();

app.UseCors(option =>
{
    option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
