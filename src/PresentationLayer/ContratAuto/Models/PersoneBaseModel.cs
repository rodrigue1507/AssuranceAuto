using DomainLayer.AggregatesModel.ContratAutoAggregate;

namespace PresentationLayer.ContratAuto.Models
{
    public class PersoneBaseModel
    {
        public string? NumeroSecuriteSocial { get; set; }
        public required string Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateDeNaissance { get; set; }
        public Sexe? Sexe { get; set; }
        public Adresse? Adresse { get; set; }
    }
}
