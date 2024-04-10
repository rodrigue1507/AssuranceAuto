
using ApplicationLayer.Abtractions;
using DomainLayer.Abstractions.repositories;
using DomainLayer.Abstractions.Services;
using DomainLayer.AggregatesModel.VoitureAggregate;
using DomainLayer.Services;
using InfrastructureLayer.Data;
using PresentationLayer.Voitures.Dtos;
using PresentationLayer.Voitures.Models;

namespace PresentationLayer.Voitures
{
    public class VoitureServicePresentationLayer : IVoitureServicePresentationLayer
    {
        private readonly IVoitureService _voitureService;
        private readonly IVoitureRepository _voitureRepository;

        public VoitureServicePresentationLayer(IVoitureService voitureService, IVoitureRepository voitureRepository)
        {
            _voitureService = voitureService;
            _voitureRepository = voitureRepository;
        }
        public async Task<VoitureDto> Create(string immatriculation)
        {
                var vtr = await _voitureService.Create(immatriculation);
                return new VoitureDto(vtr.Modele, vtr.NbPortes, vtr.Immatriculation, vtr.DateDeConstruction);
        }

        public async Task<List<VoitureDto>> GetAll(int PageSize = 10, int PageIndex = 0)
        {
            List<VoitureDto> result = new();
            var voitures =  await _voitureRepository.GetAll(PageSize, PageIndex);
            foreach (var voiture in voitures)
            {
                result.Add(new VoitureDto(voiture.Modele, voiture.NbPortes, voiture.Immatriculation, voiture.DateDeConstruction));
            }
            return result;
        }

        public async Task<VoitureDto> GetByImmatriculation(string immatriculation)
        {
            var voiture = await _voitureRepository.GetByImmatriculation(immatriculation);
            return new VoitureDto(voiture?.Modele, voiture?.NbPortes, voiture.Immatriculation, voiture?.DateDeConstruction);
        }

        public async Task<List<VoitureDto>> GetVoituresByImmatriculation(string immatriculation)
        {
            List<VoitureDto> result = new();
            var voitures = await _voitureRepository.GetVoituresByImmatriculation(immatriculation);
            foreach (var voiture in voitures)
            {
                result.Add(new VoitureDto(voiture.Modele, voiture.NbPortes, voiture.Immatriculation, voiture.DateDeConstruction));
            }
           return result;
        }

        public async Task<bool> Update(UpdateVoitureRequest updateVoitureRequest)
        {
            var voiture = await _voitureRepository.GetByImmatriculation(updateVoitureRequest.Immatriculation);
            if (voiture is null)
            {
                return false;
            }
            if (updateVoitureRequest.VoitureDto.NbPortes is not null) voiture.AjouterNbPortes((int)updateVoitureRequest.VoitureDto.NbPortes);
            if (updateVoitureRequest.VoitureDto.Modele is not null) voiture.AjouterModele(updateVoitureRequest.VoitureDto.Modele);
            if (updateVoitureRequest.VoitureDto.Immatriculation is not null) voiture.AjouterImmatriculation(updateVoitureRequest.VoitureDto.Immatriculation);
            if (updateVoitureRequest.VoitureDto.DateDeConstruction is not null) voiture.AjouterDateDeConstruction((DateTime)updateVoitureRequest.VoitureDto.DateDeConstruction);
            await _voitureRepository.Update(voiture);
            return true;
        }
    }
}
