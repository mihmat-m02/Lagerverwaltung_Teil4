using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class Produkt
    {
        public int ProduktID { get; set; }
        public string Marke { get; set; }
        public string  Name { get; set; }
        
        public decimal Preis { get; set; }
        public decimal imAngebot { get; set; }
        public string Beschreibung { get; set; }
    }
}
