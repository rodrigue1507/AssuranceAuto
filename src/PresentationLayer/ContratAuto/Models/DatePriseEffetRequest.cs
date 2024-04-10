using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ContratAuto.Models
{
    public class DatePriseEffetRequest
    {
        [FromRoute]
        public required string NumeroContrat { get; set; }
        [FromBody]
        public required DateTime DatePriseEffet { get; set; }
    }
}
