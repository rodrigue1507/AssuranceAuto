using DomainLayer.AggregatesModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AggregatesModel.ContratAutoAggregate
{
    public enum Sexe
    {
        nonDefini,
        Homme,
        Femme
    }
    public class Personne : Entity
    {
        public string? NumeroSecuriteSocial { get; private set; }
        public string Nom { get; private set; }
        public string? Prenom { get; private set; }
        public DateTime? DateDeNaissance { get; private set; }
        public Sexe? Sexe { get; private set; }
        public Adresse? Adresse { get; private set; }

        public Personne(string nom)
        {
            Nom = nom;
        }
        public void AjouterNumeroSecuriteSocial(string numeroSecuriteSocial) => NumeroSecuriteSocial = numeroSecuriteSocial;
        public void DefinirSexe(Sexe sexe) => Sexe = sexe;
        public void AjouterDateNaissance(DateTime dateDeNaissance) => DateDeNaissance = dateDeNaissance;
        public void AjouterPrenom(string prenom) => Prenom = prenom;
        public void AjouterAdresse(Adresse adresse) => Adresse = adresse;
        public override int GetHashCode() => HashCode.Combine(Id, Nom);
    }
}
