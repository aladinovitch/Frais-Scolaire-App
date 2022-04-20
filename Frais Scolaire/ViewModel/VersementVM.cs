using Frais_Scolaire.Models;

namespace Frais_Scolaire.ViewModel;
public class VersementVM
{
    public VersementVM(Eleve eleve, Paiement paiement) {
        this.Eleve = eleve;
        this.Paiement = paiement;
    }
    public Eleve? Eleve { get; set; }
    public Paiement? Paiement { get; set; }
    public string DateRange => $"{Paiement.Nom} : Du {Paiement.DateDebut.ToShortDateString()} au {Paiement.DateFin.ToShortDateString()}VM";
}
