using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.AggregatesModel.VoitureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly IVoitureRepository _voitureRepository;

        public VoitureService(IVoitureRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
        }
        public async Task<Voiture> Create(string immatriculation)
        {
            var voiture = new Voiture();
            if (String.IsNullOrEmpty(immatriculation)) throw new ArgumentNullException(" L'immatriculation est obligatoire");
            voiture.AjouterImmatriculation(immatriculation);
            return await _voitureRepository.Add(voiture);
        }
    }
}
