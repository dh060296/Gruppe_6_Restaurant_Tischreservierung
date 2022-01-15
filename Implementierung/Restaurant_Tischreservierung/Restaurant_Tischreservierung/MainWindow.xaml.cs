using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static int kundeKundennummer = 0;
        private static int reservierungsnummer = 0;

        private void KundendatenSpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            if(KundeNameTextBox.Text != "" && KundeTelefonnummerTextBox.Text != "")
            {
                RESTAURANT_TISCHRESERVIERUNGEntities Context = new RESTAURANT_TISCHRESERVIERUNGEntities();
                DbSet<Kunde> kunden = Context.Kunde;

                //richtige Kundennummer finden
                foreach (Kunde kunde in kunden)
                {
                    if(kunde.Kundennummer > kundeKundennummer)
                    {
                        kundeKundennummer = kunde.Kundennummer;
                    }
                }
                kundeKundennummer++;

                // neues Kundenobjekt erstellen
                Kunde k = new Kunde();
                k.Kundennummer = kundeKundennummer;
                k.Name = KundeNameTextBox.Text;
                k.Telefonnummer = Convert.ToInt64(KundeTelefonnummerTextBox.Text);

                // checken ob dieser Kunde schon vorhanden
                bool kundeSchonVorhanden = false;
                foreach (Kunde kunde in kunden)
                {
                    if(k.Name == kunde.Name && k.Telefonnummer == k.Telefonnummer)
                    {
                        MessageTextBox.Text = "Dieser Kunde wurde schon früher gespeichert!";
                        kundeSchonVorhanden = true;
                    }
                }

                // wenn Kunde noch nicht vorhanden, speichern
                if(!kundeSchonVorhanden)
                {
                    Context.Kunde.Add(k);
                    Context.SaveChanges();
                }
           
                KundeNameTextBox.Text = "";
                KundeTelefonnummerTextBox.Text = "";
            }
            else
            {
                MessageTextBox.Text = "Du must in beide Textboxen Daten eingeben!";
            }
        }

        public void ReservierungsdatenSpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            if(ReservierungDatumTextBox.Text != "" && ReservierungReservierungsdatumTextBox.Text != "" && 
                ReserveriungKundennummerTextBox.Text != "" && ReservierungTischnummerTextBox.Text != "")
            {
                RESTAURANT_TISCHRESERVIERUNGEntities Context = new RESTAURANT_TISCHRESERVIERUNGEntities();
                DbSet<Reservierung> reservierungen = Context.Reservierung;

                //richtige Reservierungsnummer finden
                foreach (Reservierung reservierung in reservierungen)
                {
                    if (reservierung.Reservierungsnummer > reservierungsnummer)
                    {
                        reservierungsnummer = reservierung.Reservierungsnummer;
                    }
                }
                reservierungsnummer++;

                // neues Reservierungsobjekt erstellen
                Reservierung r = new Reservierung();
                r.Reservierungsnummer = reservierungsnummer;
                r.Datum = ReservierungDatumTextBox.Text;
                r.Reservierungsdatum = ReservierungReservierungsdatumTextBox.Text;
                r.Kundennummer = Convert.ToInt32(ReserveriungKundennummerTextBox.Text);
                r.Tischnummer = Convert.ToInt32(ReservierungTischnummerTextBox.Text);

                // checken ob diese Reservierung schon vorhanden
                bool reservierungSchonVorhanden = false;
                foreach (Reservierung reservierung in reservierungen)
                {
                    if (r.Datum == reservierung.Datum && r.Reservierungsdatum == reservierung.Reservierungsdatum &&
                        r.Kundennummer == reservierung.Kundennummer && r.Tischnummer == reservierung.Tischnummer)
                    {
                        MessageTextBox.Text = "Diese Reservierung wurde schon früher gespeichert!";
                        reservierungSchonVorhanden = true;
                    }
                }

                // checken, ob Kundennummer in Kundentabelle vorhanden
                DbSet<Kunde> kunden = Context.Kunde;
                bool KundeExistiert = false;
                foreach (Kunde kunde in kunden)
                {
                    if(r.Kundennummer == kunde.Kundennummer)
                    {
                        KundeExistiert = true;
                    }
                }
                if(!KundeExistiert)
                {
                    MessageTextBox.Text = "Die angegebene Kundennummer gibt es nicht!";
                }

                // checken, ob Tischnummer in Tischtabelle vorhanden
                DbSet<Tisch> tische = Context.Tisch;
                bool TischExistiert = false;
                foreach (Tisch tisch in tische)
                {
                    if (r.Tischnummer == tisch.Tischnummer)
                    {
                        TischExistiert = true;
                    }
                }
                if (!TischExistiert)
                {
                    MessageTextBox.Text = "Die angegebene Tischnummer gibt es nicht!";
                }

                // wenn Reservierung noch nicht vorhanden, speichern
                if (!reservierungSchonVorhanden && KundeExistiert && TischExistiert)
                {
                    Context.Reservierung.Add(r);
                    Context.SaveChanges();
                }

                ReservierungDatumTextBox.Text = "";
                ReservierungReservierungsdatumTextBox.Text = "";
                ReserveriungKundennummerTextBox.Text = "";
                ReservierungTischnummerTextBox.Text = "";
            }
            else
            {
                MessageTextBox.Text = "Du must in alle 4 Textboxen Daten eingeben!";
            }
        }
    }
}
