using System.Collections.Generic;

namespace ProductDosageApp.Models
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        public string MKZ { get; set; }
        public string PrapNr { get; set; }
        public string ZVar { get; set; }
        public int Anzahl { get; set; }

        public ICollection<ProduktDosage> ProduktDosages { get; set; }
    }
}

