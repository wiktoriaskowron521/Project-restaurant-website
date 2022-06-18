using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace restauracjaTI.Models.DbModels
{
    public class RodzajDania
    {
        [Display(Name = "Rodzaj dania Id")]
        public int RodzajDaniaId { get; set; }
        [Display(Name = "Rodzaj dania")]
        public string NazwaRodzaju { get; set; }

        public List<Danie> Dania { get; set; }

        public RodzajDania()
        {
            Dania = new List<Danie>();
        }
        public RodzajDania(int rodzajDaniaId, string nazwaRodzaju, List<Danie> dania) : this()
        {
            this.RodzajDaniaId = rodzajDaniaId;
            this.NazwaRodzaju = nazwaRodzaju;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(NazwaRodzaju);
            foreach (Danie s in Dania)
            {
                sb.Append(s.ToString());
            }
            return sb.ToString();
        }

    }
}