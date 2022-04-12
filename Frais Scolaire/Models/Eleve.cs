using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Eleve
{
    public int Id { get; set; }
    
    [Required]
    public string Matricule { get; set; }
    [Required]
    public string Prenom { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public DateTime Naissance { get; set; }
    [Required]
    public string Sexe { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Adresse { get; set; }
    [Required]
    public int GroupeId { get; set; }
    
    public Groupe? Groupe { get; set; }
    
    public ICollection<Absence>? EtudiantAbsences { get; set; }
    public ICollection<Versement>? EtudiantVersements { get; set; }

    public string Fullname => $"{Nom}, {Prenom}";
}
