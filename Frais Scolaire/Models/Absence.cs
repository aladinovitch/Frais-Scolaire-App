using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Absence
{
    public int Id { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    public string Justification { get; set; }
    [Required]
    public int EtudiantId { get; set; }
    [Required]
    public int SeanceId { get; set; }
    
    public Seance? Seance { get; set; }
    public Eleve? Etudiant { get; set; }
}
