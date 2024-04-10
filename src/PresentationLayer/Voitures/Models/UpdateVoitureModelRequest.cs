namespace PresentationLayer.Voitures.Models
{
    public class UpdateVoitureModelRequest
    {
        public string? Modele { get; set; }
        public int? NbPortes { get; set; } 
        public DateTime? DateDeConstruction { get; set; }
    }
}
