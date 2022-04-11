using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class AnneeScolaire
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    
    public ICollection<Groupe>? AnneeScolaireGroupes { get; set; }
}
