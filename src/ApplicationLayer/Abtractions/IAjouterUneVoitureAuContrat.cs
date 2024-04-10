using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Abtractions
{
    public  interface IAjouterUneVoitureAuContrat
    {
        public Task Ajouter(string numeroContrat, string immatriculation);
    }
}