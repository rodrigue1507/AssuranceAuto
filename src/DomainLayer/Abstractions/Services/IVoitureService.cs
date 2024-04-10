using DomainLayer.AggregatesModel.VoitureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Abstractions.Services
{
    public interface IVoitureService
    {
        Task<Voiture> Create(string immatriculation);
    }
}
