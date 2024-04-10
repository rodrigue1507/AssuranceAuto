using ApplicationLayer.Abtractions;
using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using DomainLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AjouterUneVoitureAuContrat : IAjouterUneVoitureAuContrat
    {
        private IVoitureRepository _voitureRepository { get; }
        private IContratAutoRepository _contratAutoRepository { get; }

        public AjouterUneVoitureAuContrat(IContratAutoRepository contratAutoRepository, IVoitureRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
            _contratAutoRepository = contratAutoRepository;
        }
        public async Task Ajouter(string numeroContrat, string immatriculation)
        {
            var contratAuto = await  _contratAutoRepository.GetByNumeroContrat(numeroContrat);
            if (contratAuto is null) throw new Exception($"ce numero n'est attribué à aucun contrat; numero de contrat : {numeroContrat}");
            var voiture = await _voitureRepository.GetByImmatriculation(immatriculation);
            if (voiture is null) throw new Exception($"cette immatriculation n'est attribué à aucun véhicule; immatriculation: {immatriculation}");
            var dateDePriseEffetContrat = contratAuto.DateDePriseEffet;
            var datePriseEffetDebute = IsOnGoing(dateDePriseEffetContrat);
            if (datePriseEffetDebute) throw new Exception("aucun ajout ne peut être effectuer après la date de prise effet du contrat");
            var voitureHasAlreadyContract = await _contratAutoRepository.CheckVoitureHasAlreadyContract(voiture.Immatriculation);
            if (voitureHasAlreadyContract) throw new Exception($"Cette voiture avec l'immatriculation: {voiture.Immatriculation} est déjà associé à un contrat en cours");
            contratAuto.AjouterVoiture(voiture);
            await _contratAutoRepository.Update(contratAuto);
        }


        private bool IsOnGoing(DateTime? date)
        {
            if(date is null) return false;
            var diffDate = DateTime.Now.Date - date?.Date;
            return diffDate?.Days > 0;
        }
    }
}
