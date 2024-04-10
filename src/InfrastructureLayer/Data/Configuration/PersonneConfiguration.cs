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
    public class PersonneConfiguration : IEntityTypeConfiguration<Personne>
    {
        public void Configure(EntityTypeBuilder<Personne> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Nom)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.Prenom)
                .HasMaxLength(50);
            builder.OwnsOne(p => p.Adresse);
        }
    }
}
