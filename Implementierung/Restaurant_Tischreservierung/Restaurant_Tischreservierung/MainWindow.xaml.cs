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
            //string name = Name.Text;
            //int telefonnummer = Convert.ToInt32(Telefonnummer.Text);
            //int tischnummer = Convert.ToInt32(Tischnummer.Text);
            //DateTime reservierungsDatum = (DateTime)Reservierungsdatum.SelectedDate;

            //Kunde NeuerKunde = new Kunde();
            //NeuerKunde.Name = name;
            //NeuerKunde.Telefonnummer = telefonnummer;

            //Reservierung rsv = new Reservierung();
            //rsv.Reservierungsdatum = reservierungsDatum;
            //rsv.Datum = DateTime.Now;

            //ctx.Kunde.Add(NeuerKunde);
            //ctx.Reservierung.Add(rsv);

            ctx.SaveChanges();
        }
    }
}
