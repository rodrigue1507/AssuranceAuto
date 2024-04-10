using ApplicationLayer.Abtractions;
using ApplicationLayer.Services;
using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.Services;
using InfrastructureLayer.Data;
using InfrastructureLayer.Data.Repositories;
using InfrastructureLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi.Models;
using PresentationLayer.ContratAuto;
using PresentationLayer.Donnees;
using PresentationLayer.Voitures;
var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("ContratAutoDbContextVM");
builder.Services.AddDatabaseContext(connectionString);
builder.Services.AddScoped<IContratAutoRepository, ContratAutoRepository>();
builder.Services.AddScoped<IVoitureRepository, VoitureRepository>();
builder.Services.AddScoped<IContratAutoService, ContratAutoService>();
builder.Services.AddScoped<IVoitureService, VoitureService>();
builder.Services.AddScoped<IVoitureServicePresentationLayer, VoitureServicePresentationLayer>();
builder.Services.AddScoped<IContratAutoServicePresentationLayer, ContratAutoServicePresentationLayer>();
builder.Services.AddScoped<IAjouterUneVoitureAuContrat, AjouterUneVoitureAuContrat>();
builder.Services.AddVoitureServices();
builder.Services.AddContratAutoServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Assurance auto API",
        Description = "Api permettant de gérer des contrats autos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
//app.AddDataToDbIfNotExists();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContratAutoDbContext>();
    db.Database.Migrate();
}
app.MapContratAutoEndpoints();
app.MapVoitureEndpoints();

app.Run();
