using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Absence
{
    public int Id { get; set; }
    
    public string Justification { get; set; }
    [Required]
    [Display(Name = "Elève")]
    public int EleveId { get; set; }
    [Required]
    [Display(Name = "Séance")]
    public int SeanceId { get; set; }
    
    public Seance? Seance { get; set; }
    public Eleve? Eleve { get; set; }
}
