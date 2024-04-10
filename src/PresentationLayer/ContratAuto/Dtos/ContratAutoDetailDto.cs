using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using PresentationLayer.Voitures.Dtos;

namespace PresentationLayer.ContratAuto.Dtos
{
    public record ContratAutoDetailDto(string Numero, DateTime? DateSouscription = null, DateTime? DateDePriseEffet = null, DateTime? DateResiliation = null, SouscripteurDto? Souscripteur = null, VoitureDto? VoitureAssuree = null);
}
