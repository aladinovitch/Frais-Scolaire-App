using Frais_Scolaire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Frais_Scolaire.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<AnneeEtude> AnneeEtudes { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Trimestre> Trimestres { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Versement> Versements { get; set; }
        public DbSet<Enseignement> Enseignements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("FraisScolaire");
            modelBuilder.Entity<Enseignant>().HasMany(x => x.EnseignantMatieres).WithOne(x => x.Enseignant).HasForeignKey(x => x.EnseignantId);
            modelBuilder.Entity<Groupe>().HasMany(x => x.GroupeEleves).WithOne(x => x.Groupe).HasForeignKey(x => x.GroupeId);
            modelBuilder.Entity<Groupe>().HasMany(x => x.GroupeEnseignements).WithOne(x => x.Groupe).HasForeignKey(x => x.GroupeId);
            modelBuilder.Entity<AnneeEtude>().HasMany(x => x.AnneeEtudeGroupes).WithOne(x => x.AnneeEtude).HasForeignKey(x => x.AnneeEtudeId);
            modelBuilder.Entity<Eleve>().HasMany(x => x.EleveAbsences).WithOne(x => x.Eleve).HasForeignKey(x => x.EleveId);
            modelBuilder.Entity<Eleve>().HasMany(x => x.EleveVersements).WithOne(x => x.Eleve).HasForeignKey(x => x.EleveId);
            modelBuilder.Entity<Seance>().HasMany(x => x.SeanceAbsences).WithOne(x => x.Seance).HasForeignKey(x => x.SeanceId);
            modelBuilder.Entity<Trimestre>().HasMany(x => x.TrimestreVersements).WithOne(x => x.Trimestre).HasForeignKey(x => x.TrimestreId);
            modelBuilder.Entity<Matiere>().HasMany(x => x.MatiereSeances).WithOne(x => x.Matiere).HasForeignKey(x => x.MatiereId);
            modelBuilder.Entity<Matiere>().HasMany(x => x.MatiereEnseignements).WithOne(x => x.Matiere).HasForeignKey(x => x.MatiereId);
            modelBuilder.Entity<AnneeScolaire>().HasMany(x => x.AnneeScolaireGroupes).WithOne(x => x.AnneeScolaire).HasForeignKey(x => x.AnneeScolaireId);

            SeedUsers(modelBuilder);
            SeedData(modelBuilder);
        }
        private static void SeedUsers(ModelBuilder modelBuilder) {
            string MANAGER_ID = Guid.NewGuid().ToString();
            string BASIC_ID = Guid.NewGuid().ToString();
            var passwordHasher = new PasswordHasher<IdentityUser>();
            // Manager
            var managerName = "manager@email.com";
            var manager = new IdentityUser {
                Id = MANAGER_ID, // Primary key
                Email = managerName,
                NormalizedEmail = managerName.ToUpper(),
                UserName = managerName,
                NormalizedUserName = managerName.ToUpper(),
                EmailConfirmed = true,
            };
            manager.PasswordHash = passwordHasher.HashPassword(manager, "Pass_12345");

            // Basic user
            var basicname = "basic@email.com";
            var basic = new IdentityUser {
                Id = BASIC_ID, // Primary key
                Email = basicname,
                NormalizedEmail = basicname.ToUpper(),
                UserName = basicname,
                NormalizedUserName = basicname.ToUpper(),
                EmailConfirmed = true,
            };
            basic.PasswordHash = passwordHasher.HashPassword(basic, "Pass_12345");
            // Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(manager, basic);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
               new IdentityUserClaim<string> { Id = 1, UserId = MANAGER_ID, ClaimType = AppClaimType.Manager, ClaimValue = "true" },
               new IdentityUserClaim<string> { Id = 2, UserId = BASIC_ID, ClaimType = AppClaimType.Basic, ClaimValue = "true" });
        }
        private static void SeedData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Enseignant>().HasData(
                new Enseignant {
                    Id = 1,
                    Matricule = "E/001",
                    Prenom = "Slimane",
                    Nom = "Benslimane",
                    Phone = "05 10 10 10",
                    Email = "sli.mane@gmail.com",
                    Adresse = "Quartier Thniet el Hdjer, Médéa",
                    Statut = "Vacataire",
                    Salaire = 15000
                },
                new Enseignant {
                    Id = 2,
                    Matricule = "E/002",
                    Prenom = "Ali",
                    Nom = "Benali",
                    Phone = "05 20 20 20",
                    Email = "aliben@gmail.com",
                    Adresse = "Quartier Ain Dhheb, Médéa",
                    Statut = "Ingénieur",
                    Salaire = 50000
                },
                new Enseignant {
                    Id = 3,
                    Matricule = "E/003",
                    Prenom = "Souhila",
                    Nom = "Bousahla",
                    Phone = "05 30 30 30",
                    Email = "ss.bousahla@gmail.com",
                    Adresse = "Quartier M'salah, Médéa",
                    Statut = "Docteur",
                    Salaire = 80000
                },
                new Enseignant {
                    Id = 4,
                    Matricule = "E/004",
                    Prenom = "Amina",
                    Nom = "Amina",
                    Phone = "05 40 40 40",
                    Email = "amina.ben@gmail.com",
                    Adresse = "Quartier Merdj Echkir, Médéa",
                    Statut = "Docteur",
                    Salaire = 90000
                });

            modelBuilder.Entity<Groupe>().HasData(
                new Groupe { Id = 1, Nom = "Licence 1 G1", AnneeEtudeId = 1, AnneeScolaireId = 1 },
                new Groupe { Id = 2, Nom = "Licence 1 G1", AnneeEtudeId = 1, AnneeScolaireId = 2 },
                new Groupe { Id = 3, Nom = "Licence 1 G1", AnneeEtudeId = 1, AnneeScolaireId = 3 },
                new Groupe { Id = 4, Nom = "Licence 1 G2", AnneeEtudeId = 1, AnneeScolaireId = 3 },
                new Groupe { Id = 5, Nom = "Licence 2 G1", AnneeEtudeId = 2, AnneeScolaireId = 3 },
                new Groupe { Id = 6, Nom = "Licence 2 G2", AnneeEtudeId = 2, AnneeScolaireId = 3 },
                new Groupe { Id = 7, Nom = "Licence 2 G2", AnneeEtudeId = 2, AnneeScolaireId = 3 },
                new Groupe { Id = 8, Nom = "Licence 3 G1", AnneeEtudeId = 3, AnneeScolaireId = 3 });

            modelBuilder.Entity<Eleve>().HasData(
                new Eleve { Id = 1, Matricule = "26/15/001", Prenom = "Ahmed", Nom = "Bouhmed", Naissance = DateTime.Parse("2015-12-11"), Sexe = "Garçon", Phone = "05 01 01 01", Email = "ahmed.mido@gmail.com", Adresse = "Quartier takbou, Médéa", GroupeId = 3 },
                new Eleve { Id = 2, Matricule = "06/15/002", Prenom = "Arezki", Nom = "Benrezki", Naissance = DateTime.Parse("2015-03-10"), Sexe = "Garçon", Phone = "05 02 02 02", Email = "arezki.rzk@gmail.com", Adresse = "Quartier des fleurs, Bejaia", GroupeId = 3 },
                new Eleve { Id = 3, Matricule = "26/15/003", Prenom = "Amer", Nom = "Bouamer", Naissance = DateTime.Parse("2015-01-12"), Sexe = "Garçon", Phone = "05 03 03 03", Email = "amerrr@gmail.com", Adresse = "Quartier Bab el Kouas, Médéa", GroupeId = 3 },
                new Eleve { Id = 4, Matricule = "16/14/004", Prenom = "Sofiane", Nom = "Sidou", Naissance = DateTime.Parse("2014-02-03"), Sexe = "Garçon", Phone = "05 04 04 04", Email = "so.sidou33@bmail.com", Adresse = "Cité des roches, Réghaia", GroupeId = 4 },
                new Eleve { Id = 5, Matricule = "16/16/005", Prenom = "Samiha", Nom = "Smihi", Naissance = DateTime.Parse("2016-12-12"), Sexe = "Fille", Phone = "05 05 05 05", Email = "samimi@gmail.com", Adresse = "Quartier bouloughine, Alger", GroupeId = 4 },
                new Eleve { Id = 6, Matricule = "16/15/006", Prenom = "Fatima", Nom = "Boufetoum", Naissance = DateTime.Parse("2015-02-01"), Sexe = "Fille", Phone = "05 06 06 06", Email = "fati.bb@gmail.com", Adresse = "Cité des cinq, Belcourt", GroupeId = 4 },
                new Eleve { Id = 7, Matricule = "26/16/007", Prenom = "Samira", Nom = "Bousemar", Naissance = DateTime.Parse("2016-01-13"), Sexe = "Fille", Phone = "05 07 07 07", Email = "bousemar.sam@gmail.com", Adresse = "Route des accacias, Médéa", GroupeId = 4 });

            modelBuilder.Entity<Absence>().HasData(
                new Absence { Id = 1, Justification = "Maladie", EleveId = 5, SeanceId = 1 },
                new Absence { Id = 2, Justification = "Non justifiée", EleveId = 2, SeanceId = 2 },
                new Absence { Id = 3, Justification = "Récupération", EleveId = 5, SeanceId = 2 },
                new Absence { Id = 4, Justification = "Non justifiée", EleveId = 3, SeanceId = 2 },
                new Absence { Id = 5, Justification = "Non justifiée", EleveId = 1, SeanceId = 3 }
                );

            modelBuilder.Entity<AnneeScolaire>().HasData(
                new AnneeScolaire { Id = 1, Nom = "2019/2020" },
                new AnneeScolaire { Id = 2, Nom = "2020/2021" },
                new AnneeScolaire { Id = 3, Nom = "2021/2022" });

            modelBuilder.Entity<AnneeEtude>().HasData(
                new AnneeEtude { Id = 1, Nom = "Première année" },
                new AnneeEtude { Id = 2, Nom = "Deuxième année" },
                new AnneeEtude { Id = 3, Nom = "Troisième année" });

            modelBuilder.Entity<Matiere>().HasData(
                new Matiere { Id = 1, Nom = "Anglais : Introductory Course", EnseignantId = 3 },
                new Matiere { Id = 2, Nom = "Français : Grammaire et conjugaison", EnseignantId = 3 },
                new Matiere { Id = 3, Nom = "Math : Arithmétique", EnseignantId = 4 },
                new Matiere { Id = 4, Nom = "Math : Géométrie", EnseignantId = 4 },
                new Matiere { Id = 5, Nom = "Math : Algebre", EnseignantId = 4 },
                new Matiere { Id = 6, Nom = "Math : Théorie des graphes", EnseignantId = 4 },
                new Matiere { Id = 7, Nom = "Math : Recherche opérationnelle", EnseignantId = 4 }
                );

            modelBuilder.Entity<Seance>().HasData(
                new Seance { Id = 1, Numero = 1, Date = DateTime.Parse("2022-01-01 09:00"), MatiereId = 1 },
                new Seance { Id = 2, Numero = 2, Date = DateTime.Parse("2022-01-02 13:00"), MatiereId = 1 },
                new Seance { Id = 3, Numero = 3, Date = DateTime.Parse("2022-01-03 09:00"), MatiereId = 1 },
                new Seance { Id = 4, Numero = 4, Date = DateTime.Parse("2022-01-04 15:00"), MatiereId = 1 },
                new Seance { Id = 5, Numero = 5, Date = DateTime.Parse("2022-01-05 09:00"), MatiereId = 1 },
                new Seance { Id = 6, Numero = 6, Date = DateTime.Parse("2022-01-06 13:00"), MatiereId = 2 },
                new Seance { Id = 7, Numero = 7, Date = DateTime.Parse("2022-01-07 15:00"), MatiereId = 2 },
                new Seance { Id = 8, Numero = 8, Date = DateTime.Parse("2022-01-08 09:00"), MatiereId = 2 },
                new Seance { Id = 9, Numero = 9, Date = DateTime.Parse("2022-01-09 13:00"), MatiereId = 2 },
                new Seance { Id = 10, Numero = 10, Date = DateTime.Parse("2022-01-10 15:00"), MatiereId = 3 },
                new Seance { Id = 11, Numero = 11, Date = DateTime.Parse("2022-01-11 09:00"), MatiereId = 3 },
                new Seance { Id = 12, Numero = 12, Date = DateTime.Parse("2022-01-12 09:00"), MatiereId = 3 },
                new Seance { Id = 13, Numero = 13, Date = DateTime.Parse("2022-01-13 09:00"), MatiereId = 3 },
                new Seance { Id = 14, Numero = 14, Date = DateTime.Parse("2022-01-14 13:00"), MatiereId = 3 },
                new Seance { Id = 15, Numero = 15, Date = DateTime.Parse("2022-01-15 15:00"), MatiereId = 3 });

            modelBuilder.Entity<Enseignement>().HasData(
                new Enseignement { Id = 1, GroupeId = 1, MatiereId = 1 },
                new Enseignement { Id = 2, GroupeId = 2, MatiereId = 1 },
                new Enseignement { Id = 3, GroupeId = 3, MatiereId = 1 },
                new Enseignement { Id = 4, GroupeId = 4, MatiereId = 1 },
                new Enseignement { Id = 5, GroupeId = 1, MatiereId = 2 },
                new Enseignement { Id = 6, GroupeId = 2, MatiereId = 2 },
                new Enseignement { Id = 7, GroupeId = 3, MatiereId = 2 },
                new Enseignement { Id = 8, GroupeId = 4, MatiereId = 2 },
                new Enseignement { Id = 9, GroupeId = 3, MatiereId = 3 },
                new Enseignement { Id = 10, GroupeId = 4, MatiereId = 3 },
                new Enseignement { Id = 11, GroupeId = 3, MatiereId = 4 },
                new Enseignement { Id = 12, GroupeId = 4, MatiereId = 4 },
                new Enseignement { Id = 13, GroupeId = 3, MatiereId = 5 },
                new Enseignement { Id = 14, GroupeId = 4, MatiereId = 5 },
                new Enseignement { Id = 15, GroupeId = 3, MatiereId = 6},
                new Enseignement { Id = 16, GroupeId = 4, MatiereId = 6 });

            modelBuilder.Entity<Trimestre>().HasData(
                new Trimestre { Id = 1, Nom = "Premier trimestre", DateDebut = DateTime.Parse("2021-10-01"), DateFin = DateTime.Parse("2021-12-31") },
                new Trimestre { Id = 2, Nom = "Deuxième trimestre", DateDebut = DateTime.Parse("2022-01-01"), DateFin = DateTime.Parse("2022-03-31") },
                new Trimestre { Id = 3, Nom = "Troisième trimestre", DateDebut = DateTime.Parse("2022-04-01"), DateFin = DateTime.Parse("2022-06-30") },
                new Trimestre { Id = 4, Nom = "Premier trimestre", DateDebut = DateTime.Parse("2022-10-01"), DateFin = DateTime.Parse("2022-12-31") },
                new Trimestre { Id = 5, Nom = "Deuxième trimestre", DateDebut = DateTime.Parse("2023-01-01"), DateFin = DateTime.Parse("2023-03-31") },
                new Trimestre { Id = 6, Nom = "Troisième trimestre", DateDebut = DateTime.Parse("2023-04-01"), DateFin = DateTime.Parse("2023-06-30") },
                new Trimestre { Id = 7, Nom = "Premier trimestre", DateDebut = DateTime.Parse("2023-10-01"), DateFin = DateTime.Parse("2023-12-31") },
                new Trimestre { Id = 8, Nom = "Deuxième trimestre", DateDebut = DateTime.Parse("2024-01-01"), DateFin = DateTime.Parse("2024-03-31") },
                new Trimestre { Id = 9, Nom = "Troisième trimestre", DateDebut = DateTime.Parse("2024-04-01"), DateFin = DateTime.Parse("2024-06-30") });

            modelBuilder.Entity<Versement>().HasData(
                new Versement { Id = 1, EleveId = 1, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 2, EleveId = 2, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 3, EleveId = 3, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 4, EleveId = 4, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 5, EleveId = 5, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 6, EleveId = 6, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 7, EleveId = 7, TrimestreId = 1, Montant = 45000 },
                new Versement { Id = 8, EleveId = 1, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 9, EleveId = 2, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 10, EleveId = 3, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 11, EleveId = 4, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 12, EleveId = 5, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 13, EleveId = 6, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 14, EleveId = 7, TrimestreId = 2, Montant = 50000 },
                new Versement { Id = 15, EleveId = 1, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 16, EleveId = 2, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 17, EleveId = 3, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 18, EleveId = 4, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 19, EleveId = 5, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 20, EleveId = 6, TrimestreId = 3, Montant = 55000 },
                new Versement { Id = 21, EleveId = 7, TrimestreId = 3, Montant = 55000 });
        }
    }
}
