namespace ProductDosageApp.Models
{
    public class ProduktConfiguration
    {
        public int ProduktConfigurationID { get; set; } // Klucz główny
        public int ProduktID { get; set; } // Klucz obcy do produktu
        public int? Dos1BestandteilID { get; set; } // Opcjonalne powiązania z komponentami
        public int? Dos2BestandteilID { get; set; }
        public int? Dos3BestandteilID { get; set; }
        public int? Dos4BestandteilID { get; set; }
        public int? Dos5BestandteilID { get; set; }
        public int? Dos6BestandteilID { get; set; }
        public int? Dos7BestandteilID { get; set; }
        public int? Dos9BestandteilID { get; set; }
        public int? Dos10BestandteilID { get; set; }
        public int? Dos11BestandteilID { get; set; }

        // Nawigacja
        public virtual Produkt Produkt { get; set; }
        public virtual Bestandteil Dos1Bestandteil { get; set; }
        public virtual Bestandteil Dos2Bestandteil { get; set; }
        public virtual Bestandteil Dos3Bestandteil { get; set; }
        public virtual Bestandteil Dos4Bestandteil { get; set; }
        public virtual Bestandteil Dos5Bestandteil { get; set; }
        public virtual Bestandteil Dos6Bestandteil { get; set; }
        public virtual Bestandteil Dos7Bestandteil { get; set; }
        public virtual Bestandteil Dos9Bestandteil { get; set; }
        public virtual Bestandteil Dos10Bestandteil { get; set; }
        public virtual Bestandteil Dos11Bestandteil { get; set; }
    }
}
