using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Abstractions.Services
{
    public interface IContratAutoService
    {
        Task<ContratAuto> Create();
        public Task AjouterSouscripteur(string numeroContrat, Souscripteur souscripteur);
    }
}
