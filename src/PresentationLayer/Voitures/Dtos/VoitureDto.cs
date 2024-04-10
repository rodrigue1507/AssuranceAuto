namespace PresentationLayer.Voitures.Dtos
{
    public record VoitureDto(string? Modele, int? NbPortes, string Immatriculation, DateTime? DateDeConstruction);
}
