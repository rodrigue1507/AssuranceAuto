using DomainLayer.AggregatesModel.ContratAutoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Configuration
{
    public class SouscripteurConfiguration : IEntityTypeConfiguration<Souscripteur>
    {
        public void Configure(EntityTypeBuilder<Souscripteur> builder)
        {
            builder.OwnsOne(s => s.Adresse);
            builder.HasOne(s => s.Conjoint);
            builder.HasMany(s => s.Enfants);
        }
    }
}
