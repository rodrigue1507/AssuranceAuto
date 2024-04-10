using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PresentationLayer.Voitures.Dtos;
using PresentationLayer.Voitures.Models;
using System.Threading.Tasks;

namespace PresentationLayer.Voitures
{
    public interface IVoitureServicePresentationLayer
    {
        Task<VoitureDto> Create(string immatriculation);
        Task<VoitureDto> GetByImmatriculation(string immatriculation);
        Task<List<VoitureDto>> GetAll(int PageSize = 10, int PageIndex = 0);
        Task<List<VoitureDto>> GetVoituresByImmatriculation(string immatriculation);
        Task<bool> Update(UpdateVoitureRequest updateVoitureRequest);
    }
}