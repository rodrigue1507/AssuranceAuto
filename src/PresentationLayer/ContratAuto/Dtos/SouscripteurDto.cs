using DomainLayer.AggregatesModel.ContratAutoAggregate;
using PresentationLayer.ContratAuto.Models;

namespace PresentationLayer.ContratAuto.Dtos
{
    public record SouscripteurDto(string NumeroSecuriteSocial, string Nom, string Prenom, DateTime? DateNaissance, Sexe? Sexe, Adresse Adresse) : PersonneBaseDto(NumeroSecuriteSocial, Nom, Prenom, DateNaissance, Sexe, Adresse)
    {
        public PersonneBaseDto? Conjoint { get; set; }
        public List<PersonneBaseDto> Enfants { get; set; } = [];
    }
}
