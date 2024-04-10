using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using System.Text.Json.Serialization;

namespace PresentationLayer.ContratAuto
{
    public record ContratAutoDto(string Numero,DateTime? DateResiliation = null, DateTime? DateSouscription = null, DateTime? DatePriseEffet = null);
}
