using DomainLayer.AggregatesModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AggregatesModel.ContratAutoAggregate
{
    public sealed class Adresse : ValueObject
    {
        public string? Nom { get; private set; }
        public string? CodePostal { get; private set; }

        public static Adresse Create(string nom = "", string codePostal = "")
        {
            var adresse = new Adresse
            {
                Nom = nom,
                CodePostal = codePostal
            };
            return adresse;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Nom;
            yield return CodePostal;
        }
    }
}
