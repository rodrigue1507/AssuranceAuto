using DomainLayer.AggregatesModel.ContratAutoAggregate;

namespace PresentationLayer.ContratAuto.Models
{
    public class SouscripteurModel : PersoneBaseModel
    {
        public PersoneBaseModel? Conjoint {  get; set; }
        public List<PersoneBaseModel> Enfants { get; set; } = [];
    }
}