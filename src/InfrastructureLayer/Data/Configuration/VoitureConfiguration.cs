using DomainLayer.AggregatesModel.VoitureAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Configuration
{
    public class VoitureConfiguration : IEntityTypeConfiguration<Voiture>
    {
        public void Configure(EntityTypeBuilder<Voiture> builder)
        {
                builder.HasKey(x => x.Id);
                builder.HasIndex(o => o.Immatriculation).IsUnique();
        }
    }
}
