﻿using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Reservierung_Click(object sender, RoutedEventArgs e)
        {

            RESTAURANT_TISCHRESERVIERUNGEntities ctx = new RESTAURANT_TISCHRESERVIERUNGEntities();

            string name = Name.Text;
            uint telefonnummer = Convert.ToUInt32(Telefonnummer.Text);
            int tischnummer = Convert.ToInt32(Tischnummer.Text);
            
            
            int Kundenanzahl = ctx.Kunde.Count();
            int Reservierungsanzahl = ctx.Reservierung.Count();

            Kunde NeuerKunde = new Kunde();
            NeuerKunde.Name = name;
            NeuerKunde.Telefonnummer = telefonnummer;
            NeuerKunde.Kundennummer = Kundenanzahl + 1 ;
           

            ctx.Kunde.Add(NeuerKunde);

            Reservierung rsv = new Reservierung();

            rsv.Datum = DateTime.Now;
            rsv.Reservierungsdatum = (DateTime)ReservierungsDatum.SelectedDate;
            rsv.Reservierungsnummer = Reservierungsanzahl + 1;
            rsv.Tischnummer = tischnummer;
            rsv.Kundennummer = Kundenanzahl + 1;
            

            ctx.Reservierung.Add(rsv);

                       
            ctx.SaveChanges();


        }




    }
}
