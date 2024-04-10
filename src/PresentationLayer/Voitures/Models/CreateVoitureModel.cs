namespace PresentationLayer.Voitures.Models
{
    public class CreateVoitureModel
    {
        public CreateVoitureModel(string immatriculation)
        {
            Immatriculation = immatriculation;
        }
        public string Immatriculation { get; private set; }
    }
}
