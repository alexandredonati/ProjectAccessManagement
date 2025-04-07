using ProjectAccessManagement.Application.Services;
using ProjectAccessManagement.Domain.Repository;
using ProjectAccessManagement.Repository;
using ProjectAccessManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectAccessManagement.API.Configuration;
using ProjectAccessManagement.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();

// Configure DbContext
builder.Services.AddDbContext<ProjectAccessManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Configure Services
builder.Services.AddScoped<CredentialService>();
builder.Services.AddScoped<AppService>();
builder.Services.AddScoped<AutomationService>();
builder.Services.AddScoped<BusinessAreaService>();

// Configure Repositories
builder.Services.AddScoped<ICredentialRepository, CredentialRepository>();
builder.Services.AddScoped<IApplicationRepository, AppRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IAutomationRepository, AutomationRepository>();
builder.Services.AddScoped<IBusinessAreaRepository, BusinessAreaRepository>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.Run();
