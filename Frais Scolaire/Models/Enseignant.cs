using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Enseignant
{
    public int Id { get; set; }
    
    [Required]
    public string Matricule { get; set; }
    [Required]
    public string Prenom { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Adresse { get; set; }
    [Required]
    public string Statut { get; set; }
    [Required]
    public string Salaire { get; set; }
    
    public ICollection<Matiere>? EnseignantMatieres { get; set; }
}
