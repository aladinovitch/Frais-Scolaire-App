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
                name: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "FraisScolaire");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "FraisScolaire");

            migrationBuilder.CreateTable(
                name: "AnneeEtudes",
                schema: "FraisScolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeEtudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnneeScolaires",
                schema: "FraisScolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeScolaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Enseignants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Paiements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_AnneeEtudes_AnneeEtudeId",
                        column: x => x.AnneeEtudeId,
                        principalSchema: "FraisScolaire",
                        principalTable: "AnneeEtudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groupes_AnneeScolaires_AnneeScolaireId",
                        column: x => x.AnneeScolaireId,
                        principalSchema: "FraisScolaire",
                        principalTable: "AnneeScolaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matieres",
                schema: "FraisScolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matieres_Enseignants_EnseignantId",
                        column: x => x.EnseignantId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Enseignants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eleves_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enseignements",
                schema: "FraisScolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignements_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignements_Matieres_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Matieres_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Matieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Versements",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Versements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versements_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Versements_Paiements_PaiementId",
                        column: x => x.PaiementId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Paiements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                schema: "FraisScolaire",
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
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absences_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalSchema: "FraisScolaire",
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "AnneeEtudes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Première année" },
                    { 2, "Deuxième année" },
                    { 3, "Troisième année" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "AnneeScolaires",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "2019/2020" },
                    { 2, "2020/2021" },
                    { 3, "2021/2022" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e84516a-3697-4c22-b6f3-7435f95a44bf", 0, "a426d6c0-47b4-4caa-aaac-ded5cbf67ce2", "basic@email.com", true, false, null, "BASIC@EMAIL.COM", "BASIC@EMAIL.COM", "AQAAAAEAACcQAAAAEGO4WczZD2+Na290ZteAMTnByv6H1myE+4FMxwwiY7L34fhrzI9cIbNbJfS5RCBRVA==", null, false, "e663e86f-bc42-454a-b4b1-e93361fbfa07", false, "basic@email.com" },
                    { "fb0437ef-820d-4e15-a77d-51fdc30d84b7", 0, "1dadd3c9-e163-4ab0-82ec-afcdb040383d", "manager@email.com", true, false, null, "MANAGER@EMAIL.COM", "MANAGER@EMAIL.COM", "AQAAAAEAACcQAAAAENzHEJaqy3M4o1LAud51Wc5lWaMdWLUMvL3dA3jhhkXLlt/fAUGV8jX2xqe00jotew==", null, false, "0d904624-b1fb-4912-8da9-7b4429bca1ac", false, "manager@email.com" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "Enseignants",
                columns: new[] { "Id", "Adresse", "Email", "Matricule", "Nom", "Phone", "Prenom", "Salaire", "Statut" },
                values: new object[,]
                {
                    { 1, "Quartier Thniet el Hdjer, Médéa", "sli.mane@gmail.com", "E/001", "Benslimane", "05 10 10 10", "Slimane", 15000, "Vacataire" },
                    { 2, "Quartier Ain Dhheb, Médéa", "aliben@gmail.com", "E/002", "Benali", "05 20 20 20", "Ali", 50000, "Ingénieur" },
                    { 3, "Quartier M'salah, Médéa", "ss.bousahla@gmail.com", "E/003", "Bousahla", "05 30 30 30", "Souhila", 80000, "Docteur" },
                    { 4, "Quartier Merdj Echkir, Médéa", "amina.ben@gmail.com", "E/004", "Amina", "05 40 40 40", "Amina", 90000, "Docteur" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "Paiements",
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
                schema: "FraisScolaire",
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "true", "fb0437ef-820d-4e15-a77d-51fdc30d84b7" },
                    { 2, "Basic user", "true", "2e84516a-3697-4c22-b6f3-7435f95a44bf" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "Groupes",
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
                schema: "FraisScolaire",
                table: "Matieres",
                columns: new[] { "Id", "EnseignantId", "Nom" },
                values: new object[,]
                {
                    { 1, 3, "Anglais : Introductory Course" },
                    { 2, 3, "Français : Grammaire et conjugaison" },
                    { 3, 1, "Math : Arithmétique" },
                    { 4, 4, "Math : Géométrie" }
                });

            migrationBuilder.InsertData(
                schema: "FraisScolaire",
                table: "Eleves",
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
                schema: "FraisScolaire",
                table: "Enseignements",
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
                schema: "FraisScolaire",
                table: "Seances",
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
                schema: "FraisScolaire",
                table: "Absences",
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
                schema: "FraisScolaire",
                table: "Versements",
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
                name: "IX_Absences_EleveId",
                schema: "FraisScolaire",
                table: "Absences",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_SeanceId",
                schema: "FraisScolaire",
                table: "Absences",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Eleves_GroupeId",
                schema: "FraisScolaire",
                table: "Eleves",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignements_GroupeId",
                schema: "FraisScolaire",
                table: "Enseignements",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignements_MatiereId",
                schema: "FraisScolaire",
                table: "Enseignements",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_AnneeEtudeId",
                schema: "FraisScolaire",
                table: "Groupes",
                column: "AnneeEtudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_AnneeScolaireId",
                schema: "FraisScolaire",
                table: "Groupes",
                column: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_EnseignantId",
                schema: "FraisScolaire",
                table: "Matieres",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_MatiereId",
                schema: "FraisScolaire",
                table: "Seances",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Versements_EleveId",
                schema: "FraisScolaire",
                table: "Versements",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Versements_PaiementId",
                schema: "FraisScolaire",
                table: "Versements",
                column: "PaiementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Enseignements",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Versements",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Seances",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Eleves",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Paiements",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Matieres",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Groupes",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "Enseignants",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "AnneeEtudes",
                schema: "FraisScolaire");

            migrationBuilder.DropTable(
                name: "AnneeScolaires",
                schema: "FraisScolaire");

            migrationBuilder.DeleteData(
                schema: "FraisScolaire",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "FraisScolaire",
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "FraisScolaire",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e84516a-3697-4c22-b6f3-7435f95a44bf");

            migrationBuilder.DeleteData(
                schema: "FraisScolaire",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb0437ef-820d-4e15-a77d-51fdc30d84b7");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "FraisScolaire",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "FraisScolaire",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "FraisScolaire",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "FraisScolaire",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "FraisScolaire",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "FraisScolaire",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "FraisScolaire",
                newName: "AspNetRoleClaims");
        }
    }
}
