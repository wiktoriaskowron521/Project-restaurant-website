using System.ComponentModel.DataAnnotations;


namespace restauracjaTI.Models.DbModels
{
    public class SzczegolyZamowienia
    {
        [Display(Name = "Szczegóły zamówienia")]
        public int SzczegolyZamowieniaId { get; set; }
        [Display(Name = "Danie Id")]
        public int? DanieId { get; set; }
        public virtual Danie Danie { get; set; }
        [Display(Name = "Zamówienie Id")]
        public int? ZamowienieId { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }

        public SzczegolyZamowienia()
        {

        }

        public SzczegolyZamowienia(Zamowienie zamowienie, Danie danie)
        {
            Zamowienie = zamowienie;
            Danie = danie;
        }
    }
}