using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Versement
{
    public int Id { get; set; }
    [Required]
    public int Montant { get; set; }

    [Required]
    [Display(Name = "Elève")]
    public int EleveId { get; set; }
    [Required]
    [Display(Name = "Trimestre")]
    public int TrimestreId { get; set; }
    public Eleve? Eleve { get; set; }
    public Trimestre? Trimestre { get; set; }
}
