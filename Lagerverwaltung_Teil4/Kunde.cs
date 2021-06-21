using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class Kunde
    { 
        public int Kundennummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Adresse { get; set; }
        public bool Stammkunde { get; set; }

    }
}
