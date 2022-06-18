using System.ComponentModel.DataAnnotations;

namespace restauracjaTI.Models.DbModels
{
    public class Klient
    {
        [Display(Name = "Klient Id")]
        public int KlientId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        [Display(Name = "Kod Pocztowy")]
        public string KodPocztowy { get; set; }
        public string Telefon { get; set; }
        public string Poczta { get; set; }

        public Klient()
        { }

        public Klient(int klientId, string imie, string nazwisko, string ulica, string miasto, string kodPocztowy, string telefon, string poczta)
        {
            KlientId = klientId;
            Imie = imie;
            Nazwisko = nazwisko;
            Ulica = ulica;
            Miasto = miasto;
            KodPocztowy = kodPocztowy;
            Telefon = telefon;
            Poczta = poczta; 
        }

        public override string ToString()
        {
            return $"{Imie},{Nazwisko},{Ulica},{Miasto},{KodPocztowy},{Telefon},{Poczta}";
        }
    }
}