using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class Lager
    {
        public int LagerID { get; set; }
        public int verPLatz { get; set; }
        public string  Adresse{ get; set; }
        public Firma  FirmaID { get; set; }
    }
}
