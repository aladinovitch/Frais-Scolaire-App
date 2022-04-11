using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Matiere
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    [Required]
    public int EnseignantId { get; set; }
    
    public Enseignant? Enseignant { get; set; }
    
    public ICollection<Seance>? MatiereSeances { get; set; }
    public ICollection<Enseignement>? MatiereEnseignements { get; set; }
}
