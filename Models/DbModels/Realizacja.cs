using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restauracjaTI.Models.DbModels
{
    public class Realizacja
    {
        public int RealizacjaId { get; set; }
        public int? KlientId { get; set; }
        public int? DanieId { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Danie Danie { get; set; }
        public decimal WartoscZamowienia { get; set; }

        public Realizacja()
        {

        }
        public Realizacja(decimal wartosczamowienia)
        {
            this.WartoscZamowienia = wartosczamowienia;
        }
    }
}