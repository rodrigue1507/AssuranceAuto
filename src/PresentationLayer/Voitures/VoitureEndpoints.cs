using DomainLayer.AggregatesModel.VoitureAggregate;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Common.model;
using PresentationLayer.ContratAuto;
using PresentationLayer.Voitures.Dtos;
using PresentationLayer.Voitures.Models;
using System.Runtime.CompilerServices;

namespace PresentationLayer.Voitures
{
    public static class VoitureEndpoints
    {
        public static void MapVoitureEndpoints(this WebApplication app)
        {
            var voitures = app.MapGroup("/voiture");
            voitures.MapPost("/", CreateVoiture)
                    .WithOpenApi(operation => new(operation)
                    {
                        Summary = "enregistrer une nouvelle voiture"
                    }); 
            voitures.MapGet("/all/", GetVoitures)
                    .WithOpenApi(operation => new(operation)
                    {
                        Summary = "obtenir toutes les voitures avec pagination"
                    });
            voitures.MapGet("/allstartby/{immatriculation}", GetAllVoitureByImmatriculation)
                    .WithOpenApi(operation => new(operation)
                    {
                        Summary = "obtenir toutes les voitures commençant par l'immatriculation"
                    });
            voitures.MapGet("/{immatriculation}", GetVoitureByImmatriculation)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Obtenir la voiture par son immatriculation"
                });
            voitures.MapPut("/{immatriculation}", UpdateVoiture)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Modifier les informations d'une voiture"
                });
        }
        public static void AddVoitureServices(this IServiceCollection services)
        {
            services.AddScoped<IVoitureServicePresentationLayer, VoitureServicePresentationLayer>();
        }
        public static async Task<Results<Ok<VoitureDto>, NotFound>> GetVoitureByImmatriculation(string immatriculation, IVoitureServicePresentationLayer voitureService)
        {
            var voiture = await voitureService.GetByImmatriculation(immatriculation);
            return voiture is not null ? TypedResults.Ok(voiture) : TypedResults.NotFound();
        }
        public static async Task<Ok<List<VoitureDto>>> GetVoitures(IVoitureServicePresentationLayer voitureService)
        {
                var voitures = await voitureService.GetAll();
                return TypedResults.Ok(voitures);
        }
        public static async Task<Created<CreateVoitureModel>> CreateVoiture(string immatricultion, IVoitureServicePresentationLayer voitureService)
        {
            var voiture = await voitureService.Create(immatricultion);
            var createVoitureModel = new CreateVoitureModel(voiture.Immatriculation);
            return TypedResults.Created($"{createVoitureModel.Immatriculation}", createVoitureModel);
        }
        public async static Task<Results<Ok<bool>, NotFound>> UpdateVoiture([AsParameters] UpdateVoitureRequest updateVoitureRequest, IVoitureServicePresentationLayer voitureService)
        {
            await voitureService.Update(updateVoitureRequest);
            return TypedResults.Ok(true);
        }
        public async static Task<Results<Ok<List<VoitureDto>>, NotFound>> GetAllVoitureByImmatriculation(string immatriculation, IVoitureServicePresentationLayer voitureService)
        {
            var voitures = await voitureService.GetVoituresByImmatriculation(immatriculation);
            return voitures.Count() > 0 ? TypedResults.Ok(voitures) : TypedResults.NotFound();
        }
    }
}
