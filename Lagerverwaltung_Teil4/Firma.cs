using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class Firma
    {
        public int FirmaID { get; set; }
        public string Name { get; set; }
        public string  Adresse { get; set; }
        public int PLZ { get; set; }
        public List<Mitarbeiter> Mitarbeiters { get; set; }
        public List<Kunde> Kunden { get; set; }
    }
}
