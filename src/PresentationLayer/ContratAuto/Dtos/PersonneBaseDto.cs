using DomainLayer.AggregatesModel.ContratAutoAggregate;

namespace PresentationLayer.ContratAuto.Dtos
{
    public record PersonneBaseDto(string NumeroSecuriteSocial, string Nom, string Prenom, DateTime? DateNaissance, Sexe? Sexe, Adresse? Adresse);
}
