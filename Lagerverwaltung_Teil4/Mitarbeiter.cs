using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class Mitarbeiter
    {
        public int MitarbeiterID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Adresse { get; set; }
        public string  Abteilung { get; set; }
        public List<Kunde> Kunden { get; set; }

    
    }
}
