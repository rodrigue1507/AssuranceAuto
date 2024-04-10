using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ContratAuto.Dtos;
using PresentationLayer.Voitures.Dtos;
using PresentationLayer.Voitures.Models;

namespace PresentationLayer.ContratAuto.Models
{
    public class AddVoitureRequest
    {
        [FromRoute]
        public required string NumeroContrat { get; set; }
        [FromBody]
        public required string ImmatriculationVoiture { get; set; }
    }
}
