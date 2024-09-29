using System.Collections.Generic;

namespace ProductDosageApp.Models
{
    public class Dosage
    {
        public int DosageID { get; set; }
        public string Dos1 { get; set; }
        public string Dos2 { get; set; }
        public string Dos3 { get; set; }
        public string Dos4 { get; set; }
        public string Dos5 { get; set; }
        public string Dos6 { get; set; }
        public string Dos7 { get; set; }
        public string Dos9 { get; set; }
        public string Dos10 { get; set; }
        public string Dos11 { get; set; }

        public ICollection<ProduktDosage> ProduktDosages { get; set; }
        public ICollection<DosageBestandteil> DosageBestandteile { get; set; }
    }
}

