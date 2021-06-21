using Lagerverwaltung_Teil4;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Produkt> Produkte = new ObservableCollection<Produkt>();
        public MainWindow()
        {
            InitializeComponent();
            dgProdukt.ItemsSource = Produkte;
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Produkt> Produktee = DataManager.GetAllProdukt();
            foreach (var i in Produktee)
            {
                Produkte.Add(i);
            }
        }

        private void txtProdukt_KeyUp(object sender, KeyEventArgs e)
        {
            Produkte.Clear();

            List<Produkt> Produktee = DataManager.GetProdukt(txtProdukt.Text, "ProduktID");
            foreach (var i in Produktee)
            {
                Produkte.Add(i);
            }

        }

        private void dgProdukt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProdukt.SelectedItem != null)
            {
                Produkt p = (Produkt)dgProdukt.SelectedItem;
                imgProdukt.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\Images\" + p.ProduktID + ".jpg"));

            }
        }

        private void txtPreis_KeyUp(object sender, KeyEventArgs e)
        {
            Produkte.Clear();

            List<Produkt> Produktee = DataManager.GetProdukt(txtPreis.Text, "Preis");
            foreach (var i in Produktee)
            {
                Produkte.Add(i);
            }

        }

        private void checkSale_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Produkte.Clear();
            List<string> Werte = new List<string>{ };
            List<string> Zeile = new List<string> { };
            if (!string.IsNullOrEmpty(txtProdukt.Text)) 
            {
                Werte.Add(txtProdukt.Text);
                Zeile.Add("ProduktID");
            }
            if (!string.IsNullOrEmpty(txtMarke.Text))
            {
                Werte.Add(txtMarke.Text);
                Zeile.Add("Marke");
            }
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Werte.Add(txtName.Text);
                Zeile.Add("Name");
            }
            if (!string.IsNullOrEmpty(txtProdukt.Text))
            {
                Werte.Add(txtProdukt.Text);
                Zeile.Add("Preis");
            }
            if (checkSale.IsChecked==true)
            {
                Werte.Add("true");
                Zeile.Add("imAngebot");
            }
            if (!string.IsNullOrEmpty(txtBeschreibung.Text))
            {
                Werte.Add(txtBeschreibung.Text);
                Zeile.Add("Beschreibung");
            }
            List<Produkt> Produktee = DataManager.GetExactlyProdukt(Werte, Zeile);
            foreach (var i in Produktee)
            {
                Produkte.Add(i);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Produkte.Clear();
            List<Produkt> Produktee = DataManager.GetAllProdukt();
            foreach (var i in Produktee)
            {
                Produkte.Add(i);
            }
        }
    }
}