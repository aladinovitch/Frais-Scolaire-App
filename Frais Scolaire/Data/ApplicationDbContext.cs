using Frais_Scolaire.Models;
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
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Versement> Versements { get; set; }
        public DbSet<Enseignement> Enseignements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Enseignant>().ToTable("Enseignant", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Enseignant");

            modelBuilder.Entity<Enseignant>().ToTable("Enseignant", "Frais_Scolaire")
                .HasMany(x => x.EnseignantMatieres).WithOne(x => x.Enseignant).HasForeignKey(x => new { x.EnseignantId });

            modelBuilder.Entity<Groupe>().ToTable("Groupe", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Groupe");

            modelBuilder.Entity<Groupe>().ToTable("Groupe", "Frais_Scolaire")
                .HasMany(x => x.GroupeEleves).WithOne(x => x.Groupe).HasForeignKey(x => new { x.GroupeId });
            modelBuilder.Entity<Groupe>().ToTable("Groupe", "Frais_Scolaire")
                .HasMany(x => x.GroupeEnseignements).WithOne(x => x.Groupe).HasForeignKey(x => new { x.GroupeId });

            modelBuilder.Entity<AnneeEtude>().ToTable("AnneeEtude", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_AnneeEtude");

            modelBuilder.Entity<AnneeEtude>().ToTable("AnneeEtude", "Frais_Scolaire")
                .HasMany(x => x.AnneeEtudeGroupes).WithOne(x => x.AnneeEtude).HasForeignKey(x => new { x.AnneeEtudeId });

            modelBuilder.Entity<Eleve>().ToTable("Eleve", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Eleve");

            modelBuilder.Entity<Eleve>().ToTable("Eleve", "Frais_Scolaire")
                .HasMany(x => x.EtudiantAbsences).WithOne(x => x.Etudiant).HasForeignKey(x => new { x.EtudiantId });
            modelBuilder.Entity<Eleve>().ToTable("Eleve", "Frais_Scolaire")
                .HasMany(x => x.EtudiantVersements).WithOne(x => x.Etudiant).HasForeignKey(x => new { x.EtudiantId });

            modelBuilder.Entity<Seance>().ToTable("Seance", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Seance");

            modelBuilder.Entity<Seance>().ToTable("Seance", "Frais_Scolaire")
                .HasMany(x => x.SeanceAbsences).WithOne(x => x.Seance).HasForeignKey(x => new { x.SeanceId });

            modelBuilder.Entity<Paiement>().ToTable("Paiement", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Paiement");

            modelBuilder.Entity<Paiement>().ToTable("Paiement", "Frais_Scolaire")
                .HasMany(x => x.PaiementVersements).WithOne(x => x.Paiement).HasForeignKey(x => new { x.PaiementId });

            modelBuilder.Entity<Matiere>().ToTable("Matiere", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Matiere");

            modelBuilder.Entity<Matiere>().ToTable("Matiere", "Frais_Scolaire")
                .HasMany(x => x.MatiereSeances).WithOne(x => x.Matiere).HasForeignKey(x => new { x.MatiereId });
            modelBuilder.Entity<Matiere>().ToTable("Matiere", "Frais_Scolaire")
                .HasMany(x => x.MatiereEnseignements).WithOne(x => x.Matiere).HasForeignKey(x => new { x.MatiereId });

            modelBuilder.Entity<AnneeScolaire>().ToTable("AnneeScolaire", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_AnneeScolaire");

            modelBuilder.Entity<AnneeScolaire>().ToTable("AnneeScolaire", "Frais_Scolaire")
                .HasMany(x => x.AnneeScolaireGroupes).WithOne(x => x.AnneeScolaire).HasForeignKey(x => new { x.AnneeScolaireId });

            modelBuilder.Entity<Absence>().ToTable("Absence", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Absence");

            modelBuilder.Entity<Versement>().ToTable("Versement", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Versement");

            modelBuilder.Entity<Enseignement>().ToTable("Enseignement", "Frais_Scolaire")
                .HasKey(k => new { k.Id })
                .HasName("PK_Enseignement");
        }
    }
}