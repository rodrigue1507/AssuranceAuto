using DomainLayer.AggregatesModel.VoitureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Abstractions.repositories
{
    public interface IVoitureRepository
    {
        Task<Voiture> Add(Voiture voiture);
        Task<IEnumerable<Voiture>> GetVoituresByImmatriculation(string immatriculationLetters);
        Task<IEnumerable<Voiture>> GetAll(int pageSize, int pageIndex);
        Task<bool> CheckImmatriculationAlreadyUsed(string immatriculation);
        Task<Voiture> GetByImmatriculation(string immatriculation);
        Task Update(Voiture voiture);
    }
}
