﻿// <auto-generated />
using System;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    [DbContext(typeof(ContratAutoDbContext))]
    partial class ContratAutoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.ContratAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateDePriseEffet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateResiliation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSouscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SouscripteurId")
                        .HasColumnType("int");

                    b.Property<int?>("VoitureAssureeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Numero")
                        .IsUnique();

                    b.HasIndex("SouscripteurId");

                    b.HasIndex("VoitureAssureeId");

                    b.ToTable("ContratAutos");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroSecuriteSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Sexe")
                        .HasColumnType("int");

                    b.Property<int?>("SouscripteurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SouscripteurId");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.Souscripteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ConjointId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSecuriteSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sexe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConjointId");

                    b.ToTable("Souscripteurs");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.VoitureAggregate.Voiture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateDeConstruction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Immatriculation")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Modele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NbPortes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Immatriculation")
                        .IsUnique();

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.ContratAuto", b =>
                {
                    b.HasOne("DomainLayer.AggregatesModel.ContratAutoAggregate.Souscripteur", "Souscripteur")
                        .WithMany()
                        .HasForeignKey("SouscripteurId");

                    b.HasOne("DomainLayer.AggregatesModel.VoitureAggregate.Voiture", "VoitureAssuree")
                        .WithMany()
                        .HasForeignKey("VoitureAssureeId");

                    b.Navigation("Souscripteur");

                    b.Navigation("VoitureAssuree");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.Personne", b =>
                {
                    b.HasOne("DomainLayer.AggregatesModel.ContratAutoAggregate.Souscripteur", null)
                        .WithMany("Enfants")
                        .HasForeignKey("SouscripteurId");

                    b.OwnsOne("DomainLayer.AggregatesModel.ContratAutoAggregate.Adresse", "Adresse", b1 =>
                        {
                            b1.Property<int>("PersonneId")
                                .HasColumnType("int");

                            b1.Property<string>("CodePostal")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nom")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonneId");

                            b1.ToTable("Personne");

                            b1.WithOwner()
                                .HasForeignKey("PersonneId");
                        });

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.Souscripteur", b =>
                {
                    b.HasOne("DomainLayer.AggregatesModel.ContratAutoAggregate.Personne", "Conjoint")
                        .WithMany()
                        .HasForeignKey("ConjointId");

                    b.OwnsOne("DomainLayer.AggregatesModel.ContratAutoAggregate.Adresse", "Adresse", b1 =>
                        {
                            b1.Property<int>("SouscripteurId")
                                .HasColumnType("int");

                            b1.Property<string>("CodePostal")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nom")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SouscripteurId");

                            b1.ToTable("Souscripteurs");

                            b1.WithOwner()
                                .HasForeignKey("SouscripteurId");
                        });

                    b.Navigation("Adresse");

                    b.Navigation("Conjoint");
                });

            modelBuilder.Entity("DomainLayer.AggregatesModel.ContratAutoAggregate.Souscripteur", b =>
                {
                    b.Navigation("Enfants");
                });
#pragma warning restore 612, 618
        }
    }
}
