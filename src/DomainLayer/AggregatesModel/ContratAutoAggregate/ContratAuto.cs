using DomainLayer.AggregatesModel.Common;
using DomainLayer.AggregatesModel.VoitureAggregate;
using DomainLayer.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AggregatesModel.ContratAutoAggregate
{
    public sealed class ContratAuto: AggregateRoot
    {
        public string Numero { get;  private set; }
        public DateTime? DateSouscription { get; private set; }
        public DateTime? DateDePriseEffet { get;  private set; }
        public DateTime? DateResiliation { get;  private set; }
        public Souscripteur? Souscripteur { get;  private set; }
        public Voiture? VoitureAssuree { get;  private set; }
        public ContratAuto()
        {
            Numero = GetNumero();
        }
        public void AjouterSouscripteur(Souscripteur souscripteur) => Souscripteur = souscripteur; 
        public void AjouterVoiture(Voiture voiture) => VoitureAssuree = voiture;
        public void Resilier()
        {
            DateResiliation = DateTime.Now;
        }
        public void RenseignerPriseEffet(DateTime? datePriseEffet)
        {
            DateDePriseEffet = datePriseEffet;
        }
        public void RenseignerDateSouscription(DateTime? dateSouscription) => DateSouscription = dateSouscription;
        public double CalculerPrimeMensuelle()
        {
            return 0;
        }
        private string GetNumero()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }
}