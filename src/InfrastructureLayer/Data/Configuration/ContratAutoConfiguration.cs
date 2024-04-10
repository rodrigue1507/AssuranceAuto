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
    public class ContratAutoConfiguration : IEntityTypeConfiguration<ContratAuto>
    {
        public void Configure(EntityTypeBuilder<ContratAuto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(o => o.VoitureAssuree);
            builder.HasOne(o => o.Souscripteur);
            builder.HasIndex(o => o.Numero).IsUnique();
        }
    }
}
