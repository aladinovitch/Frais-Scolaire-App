using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Seance
{
    public int Id { get; set; }
    
    [Required]
    public int Numero { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int MatiereId { get; set; }
    
    public Matiere? Matiere { get; set; }
    
    public ICollection<Absence>? SeanceAbsences { get; set; }
}
