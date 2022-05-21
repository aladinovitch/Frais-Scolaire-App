using Frais_Scolaire.Models;
namespace Frais_Scolaire.ViewModel;

public class EnseignantVM
{
    public Enseignant Enseignant { get; set; }
    public List<Groupe> Groupes { get; set; }
    public EnseignantVM(Enseignant enseignant, List<Groupe> groupes) {
        Enseignant = enseignant;
        Groupes = groupes;
    }

}
