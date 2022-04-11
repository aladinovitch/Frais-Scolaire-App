using System.ComponentModel.DataAnnotations;

namespace Frais_Scolaire.Models;
public class Groupe
{
    public int Id { get; set; }
    
    [Required]
    public string Nom { get; set; }
    [Required]
    public int AnneeEtudeId { get; set; }
    [Required]
    public int AnneeScolaireId { get; set; }
    
    public AnneeEtude? AnneeEtude { get; set; }
    public AnneeScolaire? AnneeScolaire { get; set; }
    
    public ICollection<Eleve>? GroupeEleves { get; set; }
    public ICollection<Enseignement>? GroupeEnseignements { get; set; }
}
