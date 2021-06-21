using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lagerverwaltung_Teil4
{
    public class DataManager
    {
        private const string ConnectionString = "server=127.0.0.1;uid=root;database=lagerverwaltung";

        public static List<Kunde> GetAllKunden()
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Kunde> Kundies = new List<Kunde>();
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kunde", connection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Kunde k = new Kunde();
                    k.Kundennummer = rdr.GetInt32(0);
                    k.Vorname = rdr.GetString(1);
                    k.Nachname = rdr.GetString(2);
                    k.Adresse = rdr.GetString(3);
                    k.Stammkunde = rdr.GetBoolean(4);
                    Kundies.Add(k);
                }
                rdr.Close();
                connection.Close();
                return Kundies;

            }
        }
        public static List<Kunde> GetKunden(int ID, bool isMitarbeiter)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Kunde> Kundies = new List<Kunde>();
                MySqlDataReader rdr = null;
                connection.Open();
                if (isMitarbeiter)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kunde Where MitarbeiterID = @ID ;", connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    rdr = cmd.ExecuteReader();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Kunde Where FirmaID = @ID ;", connection);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    rdr = cmd.ExecuteReader();
                }
                while (rdr.Read())
                {
                    Kunde k = new Kunde();
                    k.Kundennummer = rdr.GetInt32(0);
                    k.Vorname = rdr.GetString(1);
                    k.Nachname = rdr.GetString(2);
                    k.Adresse = rdr.GetString(3);
                    k.Stammkunde = rdr.GetBoolean(4);
                    Kundies.Add(k);
                }
                rdr.Close();
                connection.Close();
                return Kundies;

            }
        }
        public static List<Mitarbeiter>GetAllMitarbeiter()
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Mitarbeiter> Mitarbeiters = new List<Mitarbeiter>();
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Mitarbeiter", connection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mitarbeiter m = new Mitarbeiter();
                    m.MitarbeiterID = rdr.GetInt32(0);
                    m.Vorname = rdr.GetString(1);
                    m.Nachname = rdr.GetString(2);
                    m.Adresse = rdr.GetString(3);
                    m.Abteilung = rdr.GetString(4);
                    m.Kunden = GetKunden(m.MitarbeiterID, true);
                    Mitarbeiters.Add(m);
                }
                rdr.Close();
                connection.Close();
                return Mitarbeiters;

            }
        }
        public static List<Firma> GetAllFirma()
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Firma> Firmen = new List<Firma>();
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Firma", connection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Firma f = new Firma();
                    f.FirmaID = rdr.GetInt32(0);
                    f.Name = rdr.GetString(1);
                    f.Adresse = rdr.GetString(2);
                    f.PLZ = rdr.GetInt32(3);
                    f.Kunden = GetKunden(f.FirmaID, false);
                    Firmen.Add(f);
                }
                rdr.Close();
                connection.Close();
                return Firmen;

            }
        }
        public static List<Produkt> GetAllProdukt()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Produkt> Produkten = new List<Produkt>();
                MySqlDataReader rdr = null;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Produkt", connection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Produkt p = new Produkt();
                    p.ProduktID= rdr.GetInt32(0);
                    if (rdr.IsDBNull(1) == false)
                        p.Marke = rdr.GetString(1);
                    p.Name= rdr.GetString(2);
                    if (rdr.IsDBNull(3) == false)
                        p.Beschreibung = rdr.GetString(3);
                    p.Preis = rdr.GetDecimal(4);
                    if (rdr.IsDBNull(5) == false)
                        p.imAngebot = rdr.GetDecimal(5);
                    Produkten.Add(p);
                }
                rdr.Close();
                connection.Close();
                return Produkten;

            }
        }
        public static List<Produkt> GetProdukt(string suche, string Zeile)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Produkt> Produkten = new List<Produkt>();
                MySqlDataReader rdr = null;
                connection.Open();
                decimal testde = 0m;
                int testint = 0;
                if (decimal.TryParse(suche,out testde))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Produkt Where "+Zeile+" = @suche;", connection);
                    cmd.Parameters.AddWithValue("@suche", testde);
                    rdr = cmd.ExecuteReader();

                }
                else if (int.TryParse(suche, out testint))
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Produkt Where " + Zeile + " = @suche;", connection);
                    cmd.Parameters.AddWithValue("@suche", testint);
                    rdr = cmd.ExecuteReader();

                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM Produkt Where " + Zeile + " like  '@suche%';", connection);
                    cmd.Parameters.AddWithValue("@suche", suche);
                    rdr = cmd.ExecuteReader();
                }
                while (rdr.Read())
                {
                    Produkt p = new Produkt();
                    p.ProduktID = rdr.GetInt32(0);
                    if (rdr.IsDBNull(1) == false)
                        p.Marke = rdr.GetString(1);
                    p.Name = rdr.GetString(2);
                    if (rdr.IsDBNull(3) == false)
                        p.Beschreibung = rdr.GetString(3);
                    p.Preis = rdr.GetDecimal(4);
                    if (rdr.IsDBNull(5) == false)
                        p.imAngebot = rdr.GetDecimal(5);
                    Produkten.Add(p);
                }
                rdr.Close();
                connection.Close();
                return Produkten;

            }
        }
        public static List<Produkt> GetExactlyProdukt(List<string> werte , List<string> Zeile)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                List<Produkt> Produkten = new List<Produkt>();
                MySqlDataReader rdr = null;
                connection.Open();
                string sqls = "SELECT * FROM Produkt Where ";
                for (int i = 0; i < werte.Count; i++)
                {
                    if (Zeile[i] == "ProduktID" || Zeile[i] == "Preis")
                     sqls += Zeile[i] + " =" + werte[i];
                    
                    else if (Zeile[i]=="imAngebot")
                        sqls += Zeile[i] + " is not null";

                    else
                        sqls += Zeile[i] + " like '"+ werte[i]+"%'";


                }

                MySqlCommand cmd = new MySqlCommand(sqls, connection);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Produkt p = new Produkt();
                    p.ProduktID = rdr.GetInt32(0);
                    if (rdr.IsDBNull(1) == false)
                        p.Marke = rdr.GetString(1);
                    p.Name = rdr.GetString(2);
                    if (rdr.IsDBNull(3) == false)
                        p.Beschreibung = rdr.GetString(3);
                    p.Preis = rdr.GetDecimal(4);
                    if (rdr.IsDBNull(5) == false)
                        p.imAngebot = rdr.GetDecimal(5);
                    Produkten.Add(p);
                }
                rdr.Close();
                connection.Close();
                return Produkten;

            }
        }
    }
}