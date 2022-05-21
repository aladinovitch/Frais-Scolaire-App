using Frais_Scolaire.Models;

namespace Frais_Scolaire.ViewModel;
public class VersementVM
{
    public VersementVM(Eleve eleve, Trimestre paiement) {
        Eleve = eleve;
        Paiement = paiement;
    }
    public Eleve? Eleve { get; set; }
    public Trimestre? Paiement { get; set; }
    public string DateRange => $"{Paiement.Nom} : Du {Paiement.DateDebut.ToShortDateString()} au {Paiement.DateFin.ToShortDateString()}VM";
}
