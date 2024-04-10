using DomainLayer.Abstractions.repositories;
using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Repositories
{
    public class ContratAutoRepository : IContratAutoRepository
    {
        private readonly ContratAutoDbContext _contratAutocontext;
        public ContratAutoRepository(ContratAutoDbContext contratAutoDbContext) 
        {
            _contratAutocontext = contratAutoDbContext;
        }

        public async Task<ContratAuto> Add(ContratAuto contratAuto)
        {
            await _contratAutocontext.AddAsync(contratAuto);
            await _contratAutocontext.SaveChangesAsync();
            var contrat = await GetByNumeroContrat(contratAuto.Numero);
            return contrat;
        }

        public async Task<bool> CheckVoitureHasAlreadyContract(string immatriculation)
        {
            return await _contratAutocontext.ContratAutos.AnyAsync(c => c.VoitureAssuree != null && c.VoitureAssuree.Immatriculation == immatriculation);
        }

        public async Task<ContratAuto?> GetByNumeroContrat(string numeroContrat)
        {
            var contratAuto = await _contratAutocontext.ContratAutos
                                .Include(contrat => contrat.Souscripteur)
                                .Include(contrat => contrat.VoitureAssuree)
                                .FirstOrDefaultAsync(c => c.Numero == numeroContrat);
            return contratAuto;
        }
        public async Task<IEnumerable<ContratAuto>> GetAll(int pageSize, int pageIndex)
        {
            return await _contratAutocontext.ContratAutos
            .OrderBy(c => c.Numero)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();
        }
        public async Task<IEnumerable<ContratAuto>> GetContratAutosByNumero(string numero)
        {
           return await _contratAutocontext.ContratAutos.Where(c => c.Numero.StartsWith($"{numero}")).ToListAsync();
        }

        public async Task<IEnumerable<ContratAuto>> GetContratAutosBySouscripteur(string nomSouscripteur)
        {
            var contratAutos = await _contratAutocontext.ContratAutos
                                 .Include(contrat => contrat.Souscripteur)
                                 .Where(c => c.Souscripteur != null && c.Souscripteur.Nom == nomSouscripteur)
                                 .ToListAsync();
            return contratAutos;
        }

        public async Task Update(ContratAuto contratAuto)
        {
            _contratAutocontext.Update(contratAuto);
            await _contratAutocontext.SaveChangesAsync();
        }
    }
}
