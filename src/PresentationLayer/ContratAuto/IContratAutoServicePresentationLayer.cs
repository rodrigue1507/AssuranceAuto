using PresentationLayer.ContratAuto.Dtos;
using PresentationLayer.ContratAuto.Models;

namespace PresentationLayer.ContratAuto
{
    public interface IContratAutoServicePresentationLayer
    {
        Task<string> Create();
        Task<ContratAutoDetailDto> GetByNumero(string numero);
        Task<List<ContratAutoDto>> GetBySouscripteur( string SouscripteurName);
        Task<List<ContratAutoDto>> GetContratsByNumero(string numero);
        Task<List<ContratAutoDto>> GetAll(int PageSize = 10, int PageIndex = 0);
        Task<bool> UpdateSouscripteur(AddSouscripteurRequest addSouscripteurRequest);
        Task<bool> UpdateVoiture(AddVoitureRequest addVoitureRequest);
        Task<bool> Resilier(RescindContratAutoRequest rescindContratAutoRequest);
        Task<bool> DatePriseEffet(DatePriseEffetRequest datePriseEffetRequest);
        Task<bool> DateSouscription(DateSouscripteurRequest dateSouscripteurRequest);
    }
}
