using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Restaurant_Tischreservierung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView CollectionView;
        private tischreservierungEntities ctx = new tischreservierungEntities();
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
