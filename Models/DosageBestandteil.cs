namespace ProductDosageApp.Models
{
    public class DosageBestandteil
    {
        public int DosageBestandteilID { get; set; }
        public int DosageID { get; set; }
        public int BestandteilID { get; set; }

        public Dosage Dosage { get; set; }
        public Bestandteil Bestandteil { get; set; }
    }
}

