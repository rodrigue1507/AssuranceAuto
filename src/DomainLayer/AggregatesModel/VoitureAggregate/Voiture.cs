using DomainLayer.AggregatesModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AggregatesModel.VoitureAggregate
{
    public sealed class Voiture: AggregateRoot
    {
        public string? Modele { get; private set; }
        public int? NbPortes { get; private set; }
        public string Immatriculation { get; private set; }
        public DateTime? DateDeConstruction { get; private set; }
        public void AjouterImmatriculation(string immmatriculation) => Immatriculation = immmatriculation; 
        public void AjouterNbPortes(int portes) => NbPortes = portes;
        public void AjouterDateDeConstruction(DateTime dateConstruction) => DateDeConstruction = dateConstruction;
        public void AjouterModele(string modele) => Modele = modele;
    }
}
