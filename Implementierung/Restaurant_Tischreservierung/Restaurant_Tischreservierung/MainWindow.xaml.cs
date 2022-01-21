using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Numerics;
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

namespace Restaurant_Tischreservierung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView CollectionView;
        private RESTAURANT_TISCHRESERVIERUNGEntities1 ctx = new RESTAURANT_TISCHRESERVIERUNGEntities1();

        List<Button> Buttons = new List<Button>();
        
        public MainWindow()
        {
            InitializeComponent();
            Buttons.Add(Tisch1);
            Buttons.Add(Tisch2);
            Buttons.Add(Tisch3);
            Buttons.Add(Tisch4);
            Buttons.Add(Tisch5);
            Buttons.Add(Tisch6);
            Buttons.Add(Tisch7);
            Buttons.Add(Tisch8);
            Buttons.Add(Tisch9);
            Buttons.Add(Tisch10);
            Buttons.Add(Tisch11);
            Buttons.Add(Tisch12);
            Buttons.Add(Tisch13);
            Buttons.Add(Tisch14);
            Buttons.Add(Tisch15);
            Buttons.Add(Tisch101);
            Buttons.Add(Tisch102);
            Buttons.Add(Tisch103);
            Buttons.Add(Tisch104);
            Buttons.Add(Tisch105);
            Buttons.Add(Tisch106);
            Buttons.Add(Tisch107);
            Buttons.Add(Tisch108);
            Buttons.Add(Tisch109);
            Buttons.Add(Tisch110);
            Buttons.Add(Tisch111);
            Buttons.Add(Tisch112);
            Buttons.Add(Tisch113);
            Buttons.Add(Tisch114);
            Buttons.Add(Tisch115);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctx.Reservierung.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Reservierung.Local);
            ParentGrid.DataContext = CollectionView;
        }

        private void Btn_Reservierung_Click(object sender, RoutedEventArgs e)
        {



            string name = Name.Text;
            uint telefonnummer = Convert.ToUInt32(Telefonnummer.Text);
            int tischnummer = Convert.ToInt32(Tischnummer.Text);

            int Kundenanzahl = ctx.Kunde.Count();
            int Reservierungsanzahl = ctx.Reservierung.Count();

            Kunde NeuerKunde = new Kunde();
            NeuerKunde.Name = name;
            NeuerKunde.Telefonnummer = telefonnummer;

            NeuerKunde.Kundennummer = Kundenanzahl + 1;



            ctx.Kunde.Add(NeuerKunde);

            Reservierung rsv = new Reservierung();

            int temphour = Convert.ToInt32(CB_TimeHour.Text);
            int tempmin = Convert.ToInt32(CB_TimeMinute.Text);

            string s = Reservierungsdatum.SelectedDate.ToString();
            var x = s.Split('.');
            int Tag = Convert.ToInt32(x[0]);
            int Monat = Convert.ToInt32(x[1]);
            int Jahr = Convert.ToInt32(x[2].Substring(0, 4));

            int Sekunde = 0;

            DateTime neuerVersuch = new DateTime(Jahr, Monat, Tag, temphour, tempmin, Sekunde);






            rsv.Datum = DateTime.Now;
            rsv.Reservierungsdatum = neuerVersuch;
            rsv.Reservierungsnummer = Reservierungsanzahl + 1;
            rsv.Tischnummer = tischnummer;
            rsv.Kundennummer = Kundenanzahl + 1;


            ctx.Reservierung.Add(rsv);


            ctx.SaveChanges();
        }


        private bool SchonReserviert(int Tischzahl)
        {
            string s = DatePickerInnen.SelectedDate.ToString();
            int temphour = Convert.ToInt32(CB_Stunde1.Text);
            int tempmin = Convert.ToInt32(CB_Minute1.Text);
            var x = s.Split('.');
            int Tag = Convert.ToInt32(x[0]);
            int Monat = Convert.ToInt32(x[1]);
            int Jahr = Convert.ToInt32(x[2].Substring(0, 4));
            int Sekunde = 0;

            

            DateTime Aktuelleingestellteszeitfenster = new DateTime(Jahr, Monat, Tag, temphour, tempmin, Sekunde);
            if (ctx.Reservierung.Any(y => y.Reservierungsdatum == Aktuelleingestellteszeitfenster))
            {

                var hallo = ctx.Reservierung.Where(h => h.Reservierungsdatum == Aktuelleingestellteszeitfenster).ToList();
                if (hallo.Any(g => g.Tischnummer == Tischzahl))
                {
                    return true;
                }


            }
            return false;
            
        }
        private void Tisch1_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Tisch2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Tisch3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Tisch4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch101_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch102_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch103_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch104_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch105_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch106_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch107_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch108_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch109_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch110_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch111_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch112_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch113_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch114_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tisch115_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DatePickerInnen_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Button b in Buttons)
            {
                if (SchonReserviert(Buttons.IndexOf(b) + 1)) 
                {
                    b.IsEnabled = false;
                };
            }
        }
    }
}
