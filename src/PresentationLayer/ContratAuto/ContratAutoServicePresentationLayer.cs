
using ApplicationLayer.Abtractions;
using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.AggregatesModel.ContratAutoAggregate;
using InfrastructureLayer.Data.Repositories;
using PresentationLayer.ContratAuto.Dtos;
using PresentationLayer.ContratAuto.Models;
using PresentationLayer.Voitures.Dtos;

namespace PresentationLayer.ContratAuto
{
    public class ContratAutoServicePresentationLayer : IContratAutoServicePresentationLayer
    {
        private IContratAutoService _contratAutoService { get; }
        private IContratAutoRepository _contratAutoRepository { get; }
        private IAjouterUneVoitureAuContrat _ajouterUneVoitureAuContrat { get; }

        private IVoitureRepository _voitureRepository { get; }

        public ContratAutoServicePresentationLayer(IContratAutoService contratAutoService, IContratAutoRepository contratAutoRepository, IAjouterUneVoitureAuContrat ajouterUneVoitureAuContrat, IVoitureRepository voitureRepository)
        {
            _contratAutoService = contratAutoService;
            _contratAutoRepository = contratAutoRepository;
            _ajouterUneVoitureAuContrat = ajouterUneVoitureAuContrat;
            _voitureRepository = voitureRepository;
        }


        public async Task<string> Create()
        {
            var contratAuto = await _contratAutoService.Create();
            return contratAuto.Numero;
        }

        public async Task<ContratAutoDetailDto?> GetByNumero(string numero)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(numero);
            if (contratAuto is null) return null;
            SouscripteurDto? souscripteurDto = default;
            VoitureDto? voitureDto = default;
            if (contratAuto.Souscripteur is not null)
            {
                souscripteurDto = new SouscripteurDto(contratAuto.Souscripteur?.NumeroSecuriteSocial,contratAuto.Souscripteur?.Nom, contratAuto.Souscripteur?.Prenom, contratAuto.Souscripteur.DateDeNaissance, contratAuto.Souscripteur.Sexe, contratAuto.Souscripteur?.Adresse );
            }
            if(contratAuto.VoitureAssuree is not null)
            {
                voitureDto = new VoitureDto(contratAuto.VoitureAssuree.Modele, contratAuto.VoitureAssuree.NbPortes, contratAuto.VoitureAssuree.Immatriculation, contratAuto.VoitureAssuree.DateDeConstruction);
            }
            return new ContratAutoDetailDto(contratAuto.Numero, contratAuto.DateSouscription, contratAuto.DateDePriseEffet, contratAuto.DateResiliation, souscripteurDto, voitureDto); ;
        }

        public async Task<List<ContratAutoDto>> GetBySouscripteur(string souscripteurName)
        {
            List<ContratAutoDto> results = new();
            var allContrat = await _contratAutoRepository.GetContratAutosBySouscripteur(souscripteurName);
            foreach (var contrat in allContrat)
            {
                results.Add(new ContratAutoDto(contrat.Numero,contrat.DateResiliation,contrat.DateSouscription,contrat.DateDePriseEffet));
            }
            return results;
        }

        public async Task<List<ContratAutoDto>> GetContratsByNumero(string numero)
        {
            List<ContratAutoDto> results = new();
            var allContrat = await _contratAutoRepository.GetContratAutosByNumero(numero);
            foreach (var contrat in allContrat)
            {
                results.Add(new ContratAutoDto(contrat.Numero, contrat.DateResiliation,contrat.DateSouscription, contrat.DateDePriseEffet));
            }
            return results;
        }

        
        public async Task<List<ContratAutoDto>> GetAll(int PageSize = 10, int PageIndex = 0)
        {
            List<ContratAutoDto> result = new();
            var contratAutos = await _contratAutoRepository.GetAll(PageSize, PageIndex);
            foreach (var contrat in contratAutos)
            {
                result.Add(new ContratAutoDto(contrat.Numero, contrat.DateResiliation, contrat?.DateSouscription, contrat?.DateDePriseEffet));
            }
            return result;
        }
        private static Personne UpdatePersonneModel(PersonneBaseDto personneBaseDto)
        {
            if (personneBaseDto.Nom is null) return null;
            var personne = new Personne(personneBaseDto.Nom);
            if (personneBaseDto.NumeroSecuriteSocial is not null) personne.AjouterNumeroSecuriteSocial(personneBaseDto.NumeroSecuriteSocial);
            if (personneBaseDto.DateNaissance is not null) personne.AjouterDateNaissance((DateTime)personneBaseDto.DateNaissance);
            if (personneBaseDto.Sexe is not null) personne.DefinirSexe((Sexe)personneBaseDto.Sexe);
            if (personneBaseDto.Adresse is not null) personne.AjouterAdresse(personneBaseDto.Adresse);
            if (personneBaseDto.Prenom is not null) personne.AjouterPrenom(personneBaseDto.Prenom);
            return personne;
        }

        public async Task<bool> UpdateSouscripteur(AddSouscripteurRequest addSouscripteurRequest)
        { 
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(addSouscripteurRequest.NumeroContrat);
            if(contratAuto is null)
            {
                return false;
            }
            if (addSouscripteurRequest.SouscripteurDto is not null)
            {
                var souscripteur = new Souscripteur(addSouscripteurRequest.SouscripteurDto.Nom);
                if (addSouscripteurRequest.SouscripteurDto.NumeroSecuriteSocial is not null) souscripteur.AjouterNumeroSecuriteSocial(addSouscripteurRequest.SouscripteurDto.NumeroSecuriteSocial);
                if (addSouscripteurRequest.SouscripteurDto.Sexe is not null) souscripteur.DefinirSexe((Sexe)addSouscripteurRequest.SouscripteurDto.Sexe);
                if (addSouscripteurRequest.SouscripteurDto.Conjoint is not null)
                {
                    Personne conjoint = UpdatePersonneModel(addSouscripteurRequest.SouscripteurDto.Conjoint);
                    if (conjoint is not null) souscripteur.AjouterConjoint(conjoint);
                }
                foreach (var enf in addSouscripteurRequest.SouscripteurDto.Enfants)
                {
                    var enfant = UpdatePersonneModel(enf);
                    souscripteur.AjouterEnfant(enfant);
                }
                await _contratAutoService.AjouterSouscripteur(addSouscripteurRequest.NumeroContrat, souscripteur);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateVoiture(AddVoitureRequest addVoitureRequest)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(addVoitureRequest.NumeroContrat);
            if (contratAuto is null)
            {
                return false;
            }
            var voitureAssuree = await _voitureRepository.GetByImmatriculation(addVoitureRequest.ImmatriculationVoiture);
            if(voitureAssuree is null) return false;
            await _ajouterUneVoitureAuContrat.Ajouter(contratAuto.Numero, voitureAssuree.Immatriculation);
            return true;
        }

        public async Task<bool> Resilier(RescindContratAutoRequest rescindContratAutoRequest)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(rescindContratAutoRequest.NumeroContrat);
            if (contratAuto is null)
            {
                return false;
            }
            contratAuto.Resilier();
            await  _contratAutoRepository.Update(contratAuto);
            return true;
        }

        public async Task<bool> DatePriseEffet(DatePriseEffetRequest datePriseEffetRequest)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(datePriseEffetRequest.NumeroContrat);
            if (contratAuto is null)
            {
                return false;
            }
            contratAuto.RenseignerPriseEffet(datePriseEffetRequest.DatePriseEffet);
            await _contratAutoRepository.Update(contratAuto);
            return true;
        }

        public async Task<bool> DateSouscription(DateSouscripteurRequest dateSouscripteurRequest)
        {
            var contratAuto = await _contratAutoRepository.GetByNumeroContrat(dateSouscripteurRequest.NumeroContrat);
            if (contratAuto is null)
            {
                return false;
            }
            contratAuto.RenseignerDateSouscription(dateSouscripteurRequest.DatePriseEffet);
            await _contratAutoRepository.Update(contratAuto);
            return true;
        }
    }
}
