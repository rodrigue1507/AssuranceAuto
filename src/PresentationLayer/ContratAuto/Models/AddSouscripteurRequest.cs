using PresentationLayer.ContratAuto.Dtos;

namespace PresentationLayer.ContratAuto.Models
{
    public class AddSouscripteurRequest
    {
        public required string NumeroContrat { get; set; }
        public SouscripteurDto SouscripteurDto { get; set; } = default!;
    }
}
