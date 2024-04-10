using DomainLayer.AggregatesModel.ContratAutoAggregate;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Common.model;
using PresentationLayer.ContratAuto.Dtos;
using PresentationLayer.ContratAuto.Models;
using PresentationLayer.Voitures.Dtos;

namespace PresentationLayer.ContratAuto
{
    public static class ContratAutoEndPoints
    {
        public static void MapContratAutoEndpoints(this WebApplication app)
        {
            var contratAutos = app.MapGroup("/contratAuto");
            contratAutos.MapPost("/", CreateContratAuto)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "créer un nouveau contrat"
                });

            contratAutos.MapGet("/all/", GetContratAutos)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Obtenir tous les contrats avec pagination"
                }); 
            contratAutos.MapGet("/allstartby/{numeroContrat}", GetAllContratByImmatriculation)
                .WithName("GetContratAutoByImmatriculation")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Obtenir tous les contrats commençant par le numero"
                });
            contratAutos.MapGet("/all/souscripteur/{nomSouscripteur}", GetAllContratBySouscripteur)
                .WithName("GetContratAutoBySouscripteur")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Obtenir tous les contrats associés au souscripteur"
                });
            contratAutos.MapGet("/{numeroContrat}", GetContratAutoByNumero)
                .WithOpenApi(generatedOPeration =>
                {
                    var numeroContrat = generatedOPeration.Parameters[0];
                    numeroContrat.Description = "Numero du contrat";
                    return generatedOPeration;
                })
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Obtenir le contrat par le numéro"
                });
            contratAutos.MapPut("/{numeroContrat}/ajouter-souscripteur", AddSouscripteur)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Ajouter un souscripteur à un contrat"
                });
            contratAutos.MapPut("/{numeroContrat}/ajouter-Voiture", AddVoiture)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Ajouter une voiture à un contrat"
                });
            contratAutos.MapPut("/{numeroContrat}/resilier", Resilier)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Resilier un contrat"
                });
            contratAutos.MapPut("/{numeroContrat}/date-prise-effet", DefinirDatePriseEffet)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Définir la date de prise d'effet d'un contrat"
                });
            contratAutos.MapPut("/{numeroContrat}/date-souscription", DefinirDateSouscription)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Définir la date de souscription d'un contrat"
                });
        }

        public static void AddContratAutoServices(this IServiceCollection services)
        {
            services.AddScoped<IContratAutoServicePresentationLayer, ContratAutoServicePresentationLayer>();
        }

        public static async Task<Ok<List<ContratAutoDto>>> GetContratAutos([AsParameters] PaginationRequest paginationRequest, IContratAutoServicePresentationLayer contratAutoServicePresentation)
        {
            var contratAutos = await contratAutoServicePresentation.GetAll(paginationRequest.PageSize, paginationRequest.PageIndex);
            return TypedResults.Ok(contratAutos);
        }
        public static async Task<Results<Ok<ContratAutoDetailDto>, NotFound>> GetContratAutoByNumero(string numeroContrat, IContratAutoServicePresentationLayer contratAutoServicePresentation)
        {
            var contratAuto = await contratAutoServicePresentation.GetByNumero(numeroContrat);
            return contratAuto is not null ? TypedResults.Ok(contratAuto) : TypedResults.NotFound();
        }
        public async static Task<Created<CreateContratAutoModel>> CreateContratAuto(IContratAutoServicePresentationLayer contratAutoServicePresentation)
        {
            var contratAuto = await contratAutoServicePresentation.Create();
            var createdContratAuto = new CreateContratAutoModel(contratAuto);
            return TypedResults.Created($"{createdContratAuto.NumeroContrat}", createdContratAuto);
        }
        public static async Task<Results<Ok<bool>, NotFound>> AddSouscripteur([AsParameters] AddSouscripteurRequest addSouscripteurRequest, IContratAutoServicePresentationLayer contratAutoServicePresentation)
        {
            var isUpdate = await contratAutoServicePresentation.UpdateSouscripteur(addSouscripteurRequest);
            return isUpdate ? TypedResults.Ok(true) : TypedResults.NotFound();
        }
        public static async Task<Ok<List<ContratAutoDto>>> GetAllContratByImmatriculation(string numeroContrat, IContratAutoServicePresentationLayer contratAutoServicePresentation)
        {
            var contratAutos = await contratAutoServicePresentation.GetContratsByNumero(numeroContrat);
            return TypedResults.Ok(contratAutos);
        }
        public static async Task<Results<Ok<bool>, NotFound>> AddVoiture([AsParameters] AddVoitureRequest addVoitureRequest, IContratAutoServicePresentationLayer contratAutoServicePresentationLayer)
        {
            var isUpdate = await contratAutoServicePresentationLayer.UpdateVoiture(addVoitureRequest);
            return isUpdate ? TypedResults.Ok(true) : TypedResults.NotFound();
        }
        public static async Task<Results<Ok<List<ContratAutoDto>>, NotFound>> GetAllContratBySouscripteur(string nomSouscripteur, IContratAutoServicePresentationLayer contratAutoServicePresentationLayer)
        {
            var allContrat = await contratAutoServicePresentationLayer.GetBySouscripteur(nomSouscripteur);
            if(allContrat is null) return TypedResults.NotFound();
            return TypedResults.Ok(allContrat);
        }
        public static async Task<Results<Ok, NotFound>> Resilier([AsParameters] RescindContratAutoRequest rescindContratAutoRequest, IContratAutoServicePresentationLayer contratAutoServicePresentationLayer)
        {
            var reponse = await contratAutoServicePresentationLayer.Resilier(rescindContratAutoRequest);
            return reponse ? TypedResults.Ok() : TypedResults.NotFound();
        }
        public static async Task<Results<Ok, NotFound>> DefinirDatePriseEffet([AsParameters] DatePriseEffetRequest datePriseEffetRequest, IContratAutoServicePresentationLayer contratAutoServicePresentationLayer)
        {
            var reponse = await contratAutoServicePresentationLayer.DatePriseEffet(datePriseEffetRequest);
            return reponse ? TypedResults.Ok() : TypedResults.NotFound();
        }
        public static async Task<Results<Ok, NotFound>> DefinirDateSouscription([AsParameters] DateSouscripteurRequest dateSouscripteurRequest, IContratAutoServicePresentationLayer contratAutoServicePresentationLayer)
        {
            var reponse = await contratAutoServicePresentationLayer.DateSouscription(dateSouscripteurRequest);
            return reponse ? TypedResults.Ok() : TypedResults.NotFound();
        }
    }
}
