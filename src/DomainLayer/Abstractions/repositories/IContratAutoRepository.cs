using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Abstractions.repositories
{
    public interface IContratAutoRepository
    {
        Task<ContratAuto> Add(ContratAuto contratAuto);
        Task<IEnumerable<ContratAuto>> GetContratAutosByNumero(string numero3firstLetter);
        Task<IEnumerable<ContratAuto>> GetContratAutosBySouscripteur(string nomSouscripteur);
        Task<bool> CheckVoitureHasAlreadyContract(string immatriculation);
        Task<ContratAuto> GetByNumeroContrat(string numeroContrat);
        Task<IEnumerable<ContratAuto>> GetAll(int pageSize, int pageIndex);
        Task Update(ContratAuto contratAuto);
    }
}
