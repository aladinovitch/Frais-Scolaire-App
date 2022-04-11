using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class AnneeEtude
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    
    public ICollection<Groupe>? AnneeEtudeGroupes { get; set; }
}
