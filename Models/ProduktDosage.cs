namespace ProductDosageApp.Models
{
    public class ProduktDosage
    {
        public int ProduktDosageID { get; set; }
        public int ProduktID { get; set; }
        public int DosageID { get; set; }

        public Produkt Produkt { get; set; }
        public Dosage Dosage { get; set; }
    }
}
