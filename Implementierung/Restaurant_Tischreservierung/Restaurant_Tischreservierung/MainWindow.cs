using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Restaurant_Tischreservierung
{
    public partial class MainWindow
    {
        // Gespeicherte Daten
        private ICollectionView CollectionView;

        private RESTAURANT_TISCHRESERVIERUNGEntities Context = new RESTAURANT_TISCHRESERVIERUNGEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Kunde.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Kunde.Local);
            ParentGrid.DataContext = CollectionView;
        }
    }
}
