using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Trimestre
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    [Required]
    public DateTime DateDebut { get; set; }
    [Required]
    public DateTime DateFin { get; set; }

    public ICollection<Versement>? TrimestreVersements { get; set; }

    public string DateRange => $"{Nom} : Du {DateDebut.ToShortDateString()} au {DateFin.ToShortDateString()}";
}
