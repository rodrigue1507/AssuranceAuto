using DomainLayer.AggregatesModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AggregatesModel.ContratAutoAggregate
{
    public class Souscripteur : Entity
    {
        public string? NumeroSecuriteSocial { get; private set; }
        public string Nom { get; private set; }
        public string? Prenom { get; private set; }
        public DateTime? DateDeNaissance { get; private set; }
        public Sexe? Sexe { get; private set; }
        public Adresse? Adresse { get; private set; }
        public Personne? Conjoint { get; private set; } = null;
        public ICollection<Personne> Enfants { get; private set; } = new List<Personne>();
        public Souscripteur(string nom)
        {
            Nom = nom;
        }
        public void AjouterNumeroSecuriteSocial(string numeroSecuriteSocial) => NumeroSecuriteSocial = numeroSecuriteSocial;
        public void DefinirSexe(Sexe sexe) => Sexe = sexe;
        public void AjouterDateNaissance(DateTime dateDeNaissance) => DateDeNaissance = dateDeNaissance;
        public void AjouterPrenom(string prenom) => Prenom = prenom;
        public void AjouterAdresse(Adresse adresse) => Adresse = adresse;

        public void AjouterConjoint(Personne personne)
        {
            if (Conjoint is not null) throw new Exception($"il existe déjà un conjoint d'ajouté; conjoint actuel: {Conjoint.Nom}");
            Conjoint = personne;
        }
        public void AjouterEnfant(Personne personne)
        {
            if (Enfants.Contains(personne)) throw new Exception("cet enfant a déjà été ajouté!");
            Enfants.Add(personne);
        }
        public override int GetHashCode() => HashCode.Combine(Id, Nom);
    }
}
