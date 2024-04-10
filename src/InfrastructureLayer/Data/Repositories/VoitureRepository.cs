using DomainLayer.Abstractions.repositories;
using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Repositories
{
    public class VoitureRepository : IVoitureRepository
    {
        private readonly ContratAutoDbContext _contratAutocontext;
        public VoitureRepository(ContratAutoDbContext contratAutoDbContext)
        {
            _contratAutocontext = contratAutoDbContext;
        }
        public async Task<Voiture> Add(Voiture voiture)
        {
            await _contratAutocontext.AddAsync(voiture);
            await _contratAutocontext.SaveChangesAsync();
            return await GetByImmatriculation(voiture.Immatriculation);
        }

        public async Task<bool> CheckImmatriculationAlreadyUsed(string immatriculation)
        {
            return await _contratAutocontext.Voitures.AnyAsync(v => v.Immatriculation == immatriculation);
        }

        public async Task<IEnumerable<Voiture>> GetAll(int pageSize, int pageIndex)
        {
            return await _contratAutocontext.Voitures
            .OrderBy(c => c.Modele)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<Voiture?> GetByImmatriculation(string immatriculation)
        {
            return await _contratAutocontext.Voitures.FirstOrDefaultAsync(v => v.Immatriculation == immatriculation);
        }

        public async Task<IEnumerable<Voiture>> GetVoituresByImmatriculation(string immatriculationLetters)
        {
            return await _contratAutocontext.Voitures.Where(v => v.Immatriculation.StartsWith($"{immatriculationLetters}")).ToListAsync();
        }

        public async Task Update(Voiture voiture)
        {
            _contratAutocontext.Voitures.Update(voiture);
            await _contratAutocontext.SaveChangesAsync();
        }
    }
}
