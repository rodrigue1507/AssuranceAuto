namespace PresentationLayer.ContratAuto.Models
{
    public class CreateContratAutoModel
    {
        public CreateContratAutoModel( string numeroContrat)
        {
            NumeroContrat = numeroContrat;
        }
        public string NumeroContrat { get; private set; }
    }
}
    