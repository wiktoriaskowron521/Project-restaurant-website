using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace restauracjaTI.Models.DbModels
{
    public class Danie
    {
        [Display(Name = "Danie Id")]
        public int DanieId { get; set; }
        [Display(Name = "Rodzaj danie id")]
        public int? RodzajDaniaId { get; set; }
        [Display(Name = "Nazwa dania")]
        public string NazwaDania { get; set; }
        [Display(Name = "Opis dania")]
        public string OpisDania { get; set; }
        [Display(Name = "Cena dania")]
        public decimal CenaDania { get; set; }
        [Display(Name = "Bestseller")]
        public bool Bestseller { get; set; }
        [Display(Name = "Rodzaj dania")]
        public virtual RodzajDania RodzajDania { get; set; }

        public Danie()
        {

        }
        public Danie(int danieiD, string nazwadania, string opisdania, decimal cenadania, bool bestseller)
        {
            this.DanieId = danieiD;
            this.NazwaDania = nazwadania;
            this.OpisDania = opisdania;
            this.CenaDania = cenadania;
            this.Bestseller = bestseller;

        }

        public override string ToString()
        {
            return $"{NazwaDania}, OpisDania:{OpisDania}, Cena:{CenaDania} ,Bestseller:{Bestseller}";
        }
    }
}