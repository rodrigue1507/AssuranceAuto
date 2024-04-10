using PresentationLayer.Voitures.Dtos;

namespace PresentationLayer.Voitures.Models
{
    public class UpdateVoitureRequest
    {
        public required string Immatriculation { get; set; }
        public required VoitureDto VoitureDto { get; set; }
    }
}
