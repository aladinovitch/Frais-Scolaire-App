using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Enseignement
{
    public int Id { get; set; }
    
    [Required]
    public int GroupeId { get; set; }
    [Required]
    public int MatiereId { get; set; }
    
    public Groupe? Groupe { get; set; }
    public Matiere? Matiere { get; set; }
}
