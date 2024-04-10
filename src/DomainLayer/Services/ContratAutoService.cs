using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;

namespace DomainLayer.Services
{
    public class ContratAutoService : IContratAutoService
    {
        private readonly IContratAutoRepository _contratAutoRepository;
        public ContratAutoService(IContratAutoRepository contratAutoRepository)
        {
            _contratAutoRepository = contratAutoRepository;
        }
        public async Task<ContratAuto> Create()
        {
            return await _contratAutoRepository.Add(new ContratAuto());
        }
        public async Task AjouterSouscripteur(string numeroContrat, Souscripteur souscripteur)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(numeroContrat);
            // conditionner en fonction de la date de prise effet du contrat
            if (contratAuto.Souscripteur is not null) throw new Exception($"un souscripteur est déjà associé au contrat; souscripteur:{contratAuto.Souscripteur}");
            contratAuto.AjouterSouscripteur(souscripteur);
            await _contratAutoRepository.Update(contratAuto);
        }
    }
}
