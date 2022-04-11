using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Paiement
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    [Required]
    public DateTime DateDebut { get; set; }
    [Required]
    public DateTime DateFin { get; set; }

    public ICollection<Versement>? PaiementVersements { get; set; }
}
