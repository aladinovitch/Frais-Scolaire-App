using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frais_Scolaire.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Frais_Scolaire");

            migrationBuilder.CreateTable(
                name: "AnneeEtude",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeEtude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnneeScolaire",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeScolaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salaire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiement",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupe",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeEtudeId = table.Column<int>(type: "int", nullable: false),
                    AnneeScolaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupe_AnneeEtude_AnneeEtudeId",
                        column: x => x.AnneeEtudeId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "AnneeEtude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groupe_AnneeScolaire_AnneeScolaireId",
                        column: x => x.AnneeScolaireId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "AnneeScolaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matiere_Enseignant_EnseignantId",
                        column: x => x.EnseignantId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Enseignant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eleve",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eleve_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enseignement",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignement_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignement_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Matiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seance_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Matiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versement",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    PaiementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versement_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Versement_Paiement_PaiementId",
                        column: x => x.PaiementId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Paiement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                schema: "Frais_Scolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    SeanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absence_Eleve_EleveId",
                        column: x => x.EleveId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Eleve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absence_Seance_SeanceId",
                        column: x => x.SeanceId,
                        principalSchema: "Frais_Scolaire",
                        principalTable: "Seance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "AnneeEtude",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Première année" },
                    { 2, "Deuxième année" },
                    { 3, "Troisième année" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "AnneeScolaire",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "2019/2020" },
                    { 2, "2020/2021" },
                    { 3, "2021/2022" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a3a2c66d-a9c9-4a64-a95a-a75b8b986de7", 0, "77d8fcc5-671d-4ef3-ab6d-e276b68cb8d3", "basic@email.com", true, false, null, "BASIC@EMAIL.COM", "BASIC@EMAIL.COM", "AQAAAAEAACcQAAAAEMIi7OKiWI2oarRGJ4RptoS7XkmwGBcFpBtu6jfxDpEmEL7NgxciZriw+e0V/xG8bg==", null, false, "daf00206-2021-45b7-aadd-d37d6edaaaea", false, "basic@email.com" },
                    { "d36ba5b8-0356-45e6-9db5-3ded5e9e57fa", 0, "667a927e-41b2-4b2b-9510-2d95e05ae86e", "manager@email.com", true, false, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAEAACcQAAAAEO6z034lAW18bDcwpwmxK3CtfjGAfGY/6BJ1CVxk9fog7LRkHv/yEobLr3dKaVDGnA==", null, false, "977be332-636e-47c7-b091-faceb8ccf106", false, "manager@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Enseignant",
                columns: new[] { "Id", "Adresse", "Email", "Matricule", "Nom", "Phone", "Prenom", "Salaire", "Statut" },
                values: new object[,]
                {
                    { 1, "Quartier Thniet el Hdjer, Médéa", "sli.mane@gmail.com", "E/001", "Benslimane", "05 10 10 10", "Slimane", 15000, "Vacataire" },
                    { 2, "Quartier Ain Dhheb, Médéa", "aliben@gmail.com", "E/002", "Benali", "05 20 20 20", "Ali", 50000, "Ingénieur" },
                    { 3, "Quartier M'salah, Médéa", "ss.bousahla@gmail.com", "E/003", "Bousahla", "05 30 30 30", "Souhila", 80000, "Docteur" },
                    { 4, "Quartier Merdj Echkir, Médéa", "amina.ben@gmail.com", "E/004", "Amina", "05 40 40 40", "Amina", 90000, "Docteur" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Paiement",
                columns: new[] { "Id", "DateDebut", "DateFin", "Nom" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premier trimestre" },
                    { 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deuxième trimestre" },
                    { 3, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troisième trimestre" },
                    { 4, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premier trimestre" },
                    { 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deuxième trimestre" },
                    { 6, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troisième trimestre" },
                    { 7, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premier trimestre" },
                    { 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deuxième trimestre" },
                    { 9, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troisième trimestre" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "true", "d36ba5b8-0356-45e6-9db5-3ded5e9e57fa" },
                    { 2, "Basic user", "true", "a3a2c66d-a9c9-4a64-a95a-a75b8b986de7" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Groupe",
                columns: new[] { "Id", "AnneeEtudeId", "AnneeScolaireId", "Nom" },
                values: new object[,]
                {
                    { 1, 1, 1, "Licence 1 G1" },
                    { 2, 1, 2, "Licence 1 G1" },
                    { 3, 1, 3, "Licence 1 G1" },
                    { 4, 1, 3, "Licence 1 G2" },
                    { 5, 2, 3, "Licence 2 G1" },
                    { 6, 2, 3, "Licence 2 G2" },
                    { 7, 2, 3, "Licence 2 G2" },
                    { 8, 3, 3, "Licence 3 G1" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Matiere",
                columns: new[] { "Id", "EnseignantId", "Nom" },
                values: new object[,]
                {
                    { 1, 3, "Anglais : Introductory Course" },
                    { 2, 3, "Français : Grammaire et conjugaison" },
                    { 3, 1, "Math : Arithmétique" },
                    { 4, 4, "Math : Géométrie" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Eleve",
                columns: new[] { "Id", "Adresse", "Email", "GroupeId", "Matricule", "Naissance", "Nom", "Phone", "Prenom", "Sexe" },
                values: new object[,]
                {
                    { 1, "Quartier takbou, Médéa", "ahmed.mido@gmail.com", 3, "26/15/001", new DateTime(2015, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouhmed", "05 01 01 01", "Ahmed", "Garçon" },
                    { 2, "Quartier des fleurs, Bejaia", "arezki.rzk@gmail.com", 3, "06/15/002", new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benrezki", "05 02 02 02", "Arezki", "Garçon" },
                    { 3, "Quartier Bab el Kouas, Médéa", "amerrr@gmail.com", 3, "26/15/003", new DateTime(2015, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouamer", "05 03 03 03", "Amer", "Garçon" },
                    { 4, "Cité des roches, Réghaia", "so.sidou33@bmail.com", 4, "16/14/004", new DateTime(2014, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sidou", "05 04 04 04", "Sofiane", "Garçon" },
                    { 5, "Quartier bouloughine, Alger", "samimi@gmail.com", 4, "16/16/005", new DateTime(2016, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smihi", "05 05 05 05", "Samiha", "Fille" },
                    { 6, "Cité des cinq, Belcourt", "fati.bb@gmail.com", 4, "16/15/006", new DateTime(2015, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boufetoum", "05 06 06 06", "Fatima", "Fille" },
                    { 7, "Route des accacias, Médéa", "bousemar.sam@gmail.com", 4, "26/16/007", new DateTime(2016, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bousemar", "05 07 07 07", "Samira", "Fille" }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Enseignement",
                columns: new[] { "Id", "GroupeId", "MatiereId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 3, 2 }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Seance",
                columns: new[] { "Id", "Date", "MatiereId", "Numero" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2022, 1, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2022, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2022, 1, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, new DateTime(2022, 1, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 7, new DateTime(2022, 1, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 8, new DateTime(2022, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 },
                    { 9, new DateTime(2022, 1, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 10, new DateTime(2022, 1, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, 10 },
                    { 11, new DateTime(2022, 1, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 11 },
                    { 12, new DateTime(2022, 1, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 12 },
                    { 13, new DateTime(2022, 1, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 3, 13 },
                    { 14, new DateTime(2022, 1, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 3, 14 },
                    { 15, new DateTime(2022, 1, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, 15 }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Absence",
                columns: new[] { "Id", "EleveId", "Justification", "SeanceId" },
                values: new object[,]
                {
                    { 1, 5, "Maladie", 1 },
                    { 2, 2, "Non justifiée", 2 },
                    { 3, 5, "Récupération", 2 },
                    { 4, 3, "Non justifiée", 2 },
                    { 5, 1, "Non justifiée", 3 }
                });

            migrationBuilder.InsertData(
                schema: "Frais_Scolaire",
                table: "Versement",
                columns: new[] { "Id", "EleveId", "Montant", "PaiementId" },
                values: new object[,]
                {
                    { 1, 1, 45000, 1 },
                    { 2, 2, 45000, 1 },
                    { 3, 3, 45000, 1 },
                    { 4, 4, 45000, 1 },
                    { 5, 5, 45000, 1 },
                    { 6, 6, 45000, 1 },
                    { 7, 7, 45000, 1 },
                    { 8, 1, 50000, 2 },
                    { 9, 2, 50000, 2 },
                    { 10, 3, 50000, 2 },
                    { 11, 4, 50000, 2 },
                    { 12, 5, 50000, 2 },
                    { 13, 6, 50000, 2 },
                    { 14, 7, 50000, 2 },
                    { 15, 1, 55000, 3 },
                    { 16, 2, 55000, 3 },
                    { 17, 3, 55000, 3 },
                    { 18, 4, 55000, 3 },
                    { 19, 5, 55000, 3 },
                    { 20, 6, 55000, 3 },
                    { 21, 7, 55000, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_EleveId",
                schema: "Frais_Scolaire",
                table: "Absence",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_SeanceId",
                schema: "Frais_Scolaire",
                table: "Absence",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleve_GroupeId",
                schema: "Frais_Scolaire",
                table: "Eleve",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignement_GroupeId",
                schema: "Frais_Scolaire",
                table: "Enseignement",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignement_MatiereId",
                schema: "Frais_Scolaire",
                table: "Enseignement",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_AnneeEtudeId",
                schema: "Frais_Scolaire",
                table: "Groupe",
                column: "AnneeEtudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupe_AnneeScolaireId",
                schema: "Frais_Scolaire",
                table: "Groupe",
                column: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_EnseignantId",
                schema: "Frais_Scolaire",
                table: "Matiere",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_MatiereId",
                schema: "Frais_Scolaire",
                table: "Seance",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Versement_EleveId",
                schema: "Frais_Scolaire",
                table: "Versement",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Versement_PaiementId",
                schema: "Frais_Scolaire",
                table: "Versement",
                column: "PaiementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Enseignement",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Versement",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Seance",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Eleve",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Paiement",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Matiere",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Groupe",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "Enseignant",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "AnneeEtude",
                schema: "Frais_Scolaire");

            migrationBuilder.DropTable(
                name: "AnneeScolaire",
                schema: "Frais_Scolaire");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3a2c66d-a9c9-4a64-a95a-a75b8b986de7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d36ba5b8-0356-45e6-9db5-3ded5e9e57fa");
        }
    }
}
