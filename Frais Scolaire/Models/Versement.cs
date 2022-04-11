using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Versement
{
    public int Id { get; set; }
    
    [Required]
    public int EtudiantId { get; set; }
    [Required]
    public int PaiementId { get; set; }
    
    public Paiement? Paiement { get; set; }
    public Eleve? Etudiant { get; set; }
}
