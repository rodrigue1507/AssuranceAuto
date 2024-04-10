using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPortes = table.Column<int>(type: "int", nullable: true),
                    Immatriculation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateDeConstruction = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContratAutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSouscription = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDePriseEffet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateResiliation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SouscripteurId = table.Column<int>(type: "int", nullable: true),
                    VoitureAssureeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratAutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratAutos_Voitures_VoitureAssureeId",
                        column: x => x.VoitureAssureeId,
                        principalTable: "Voitures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSecuriteSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Adresse_Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SouscripteurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Souscripteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSecuriteSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Adresse_Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse_CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConjointId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Souscripteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Souscripteurs_Personne_ConjointId",
                        column: x => x.ConjointId,
                        principalTable: "Personne",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratAutos_Numero",
                table: "ContratAutos",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContratAutos_SouscripteurId",
                table: "ContratAutos",
                column: "SouscripteurId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratAutos_VoitureAssureeId",
                table: "ContratAutos",
                column: "VoitureAssureeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_SouscripteurId",
                table: "Personne",
                column: "SouscripteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Souscripteurs_ConjointId",
                table: "Souscripteurs",
                column: "ConjointId");

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_Immatriculation",
                table: "Voitures",
                column: "Immatriculation",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContratAutos_Souscripteurs_SouscripteurId",
                table: "ContratAutos",
                column: "SouscripteurId",
                principalTable: "Souscripteurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Souscripteurs_SouscripteurId",
                table: "Personne",
                column: "SouscripteurId",
                principalTable: "Souscripteurs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Souscripteurs_SouscripteurId",
                table: "Personne");

            migrationBuilder.DropTable(
                name: "ContratAutos");

            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropTable(
                name: "Souscripteurs");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
