using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class LagerHatProdukt
    {
        public Lager LagerID { get; set; }
        public Produkt ProduktID { get; set; }
        public int Stückzahl { get; set; }
    }
}
