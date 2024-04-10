using DomainLayer.AggregatesModel.ContratAutoAggregate;
using DomainLayer.AggregatesModel.VoitureAggregate;
using InfrastructureLayer.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data
{
    public class ContratAutoDbContext : DbContext
    {
        public ContratAutoDbContext(DbContextOptions<ContratAutoDbContext> options):base(options)
        {}
        public DbSet<ContratAuto> ContratAutos { get; set; }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Souscripteur> Souscripteurs { get; set; }
        public DbSet<Personne> Personnes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContratAutoConfiguration());
            modelBuilder.ApplyConfiguration(new VoitureConfiguration());
            modelBuilder.ApplyConfiguration(new SouscripteurConfiguration());
            modelBuilder.ApplyConfiguration(new PersonneConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
