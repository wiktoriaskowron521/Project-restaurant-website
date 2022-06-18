using System.ComponentModel.DataAnnotations;


namespace restauracjaTI.Models.DbModels
{
    public class Zamowienie
    {
        [Display(Name = "Zamówienie Id")]
        public int ZamowienieId { get; set; }
        [Display(Name = "Klient Id")]
        public int? KlientId { get; set; }
        public virtual Klient Klient { get; set; }
        [Display(Name = "Wartość zamówienia")]
        public decimal WartoscZamowienia { get; set; }

        public Zamowienie()
        {

        }
        public Zamowienie(decimal wartosczamowienia)
        {
            this.WartoscZamowienia = wartosczamowienia;
        }
    }
}