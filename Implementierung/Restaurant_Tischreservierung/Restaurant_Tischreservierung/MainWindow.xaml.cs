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
        private RESTAURANT_TISCHRESERVIERUNGEntities ctx = new RESTAURANT_TISCHRESERVIERUNGEntities();
        List<Button> Buttons = new List<Button>();
        private int anzahlReservierungen;
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
            TiInnen.Focus();

            anzahlReservierungen = ctx.Reservierung.Count();
            ReservierungsAnzahl.Content = $"Anzahl Reservierungen: {anzahlReservierungen}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctx.Reservierung.Load();
            CollectionView = CollectionViewSource.GetDefaultView(ctx.Reservierung.Local);
            ParentGrid.DataContext = CollectionView;
        }

        private void Btn_Pruefen_Click(object sender, RoutedEventArgs e)
        {
            Kunde NeuerKunde = new Kunde();
            try
            {
                if (Name.Text == "")
                {
                    throw new LeeresFeldException("Namensfeld leer");

                }
                string name = Name.Text;
                NeuerKunde.Name = name;

            }
            catch
            {
                MeldungNameLabel.Content = "Bitte geben füllen das Namensfeld aus!";
            }

            try
            {
                if (Telefonnummer.Text == "")
                {
                    throw new LeeresFeldException("Telefonnummerfeld leer");
                }
                
                NeuerKunde.Telefonnummer = Telefonnummer.Text;
            }
            catch
            {
                MeldungTelefonLabel.Content = "Bitte geben Sie eine gültige Telefonnummer ein!";
            }
            int tischnummer = Convert.ToInt32(Tischnummer.Text);

            Reservierung rsv = new Reservierung();

            int temphour = Convert.ToInt32(CB_TimeHour.Text);
            int tempmin = Convert.ToInt32(CB_TimeMinute.Text);

            string s = Reservierungsdatum.SelectedDate.ToString();
            var x = s.Split('.');
            int Tag = Convert.ToInt32(x[0]);
            int Monat = Convert.ToInt32(x[1]);
            int Jahr = Convert.ToInt32(x[2].Substring(0, 4));

            int Sekunde = 0;

            DateTime ResDatum = new DateTime(Jahr, Monat, Tag, temphour, tempmin, Sekunde);

            try
            {
                if (ResDatum < DateTime.Now)
                {
                    throw new DatumException("ungültiges Datum");
                }
                rsv.Reservierungsdatum = ResDatum;
            }
            catch
            {
                MeldungDatumLabel.Content = "Ihr Reservierungsdatum darf nicht vor dem heutigen Tag liegen";
            }

            if(Name.Text != "" && Telefonnummer.Text != "" && ResDatum > DateTime.Now)
            {
                int Kundenanzahl = ctx.Kunde.Count();
                int Reservierungsanzahl = ctx.Reservierung.Count();

                NeuerKunde.Kundennummer = Kundenanzahl + 1;
                ctx.Kunde.Add(NeuerKunde);
                rsv.Datum = DateTime.Now;


                rsv.Tischnummer = tischnummer;
                rsv.Kundennummer = Kundenanzahl + 1;
                
                ctx.Reservierung.Add(rsv);
                MeldungNameLabel.Foreground = Brushes.Green;
                MeldungNameLabel.Content = "Die Reservierung kann eingetragen werden.";
                MeldungTelefonLabel.Content = "";
                MeldungDatumLabel.Content = "";
                Btn_Reservierung.IsEnabled = true;
                
            }
        }
        private void Btn_Reservierung_Click(object sender, RoutedEventArgs e)
        {
            ctx.SaveChanges();
            MessageBox.Show("Tisch wurde reserviert.");
            Name.Text = "";
            Telefonnummer.Text = "";
            Tischnummer.Text = "";
            MeldungNameLabel.Content = "";
            TiInnen.Focus();
            anzahlReservierungen += 1;
            ReservierungsAnzahl.Content = $"Anzahl Reservierungen: {anzahlReservierungen}";
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

        private void DatePickerInnen_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Button b in Buttons)
            {
                if (SchonReserviert(Buttons.IndexOf(b) + 1))
                {
                    b.IsEnabled = false;
                    b.Foreground = Brushes.Red;


                }
                else
                {
                    b.IsEnabled = true;
                    b.Foreground = Brushes.Black;
                    b.Background = Brushes.Green;
                }
            }
        }

        private void Tisch1_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "1";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch2_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "2";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch3_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "3";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch4_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "4";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch5_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "5";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch6_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "6";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch7_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "7";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch8_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "8";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch9_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "9";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch10_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "10";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch11_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "11";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch12_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "12";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch13_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "13";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch14_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "14";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch15_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "15";
            Reservierungsdatum.SelectedDate = DatePickerInnen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde1.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute1.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch101_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "101";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch102_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "102";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch103_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "103";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch104_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "104";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch105_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "105";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch106_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "106";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch107_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "107";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch108_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "108";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch109_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "109";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch110_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "110";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch111_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "111";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch112_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "112";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch113_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "113";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch114_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "114";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void Tisch115_Click(object sender, RoutedEventArgs e)
        {
            Tischnummer.Text = "115";
            Reservierungsdatum.SelectedDate = DatePickerAußen.SelectedDate;
            CB_TimeHour.SelectedIndex = CB_Stunde2.SelectedIndex;
            CB_TimeMinute.SelectedIndex = CB_Minute2.SelectedIndex;

            TiRes.IsSelected = true;
        }

        private void KundenSuche_TextChanged(object sender, TextChangedEventArgs e)
        {
                string filter = KundenSuche.Text.ToLower();
                CollectionView.Filter = (x => ((Reservierung)x).Kunde.Name.ToLower().Contains(filter));
        }

        private void CB_Stunde2_LostFocus(object sender, RoutedEventArgs e)
        {
            foreach (Button b in Buttons)
            {
                if (SchonReserviert(Buttons.IndexOf(b) + 1))
                {
                    b.IsEnabled = false;
                    b.Foreground = Brushes.Red;


                }
                else
                {
                    b.IsEnabled = true;
                    b.Foreground = Brushes.Black;
                    b.Background = Brushes.Green;
                }
            }
        }

        private void BtnVor_Click(object sender, RoutedEventArgs e)
        {
                CollectionView.MoveCurrentToNext();
                if (CollectionView.IsCurrentAfterLast)
                {
                    CollectionView.MoveCurrentToFirst();
                }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
                CollectionView.MoveCurrentToLast();
                if (CollectionView.IsCurrentAfterLast)
                {
                    CollectionView.MoveCurrentToLast();
                }
        }
    }
}
