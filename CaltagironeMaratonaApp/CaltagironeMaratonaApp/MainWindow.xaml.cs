using System;
using System.Collections.Generic;
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

namespace CaltagironeMaratonaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ElencoMaratone elenco;
        public MainWindow()
        {
            InitializeComponent();
            elenco = new ElencoMaratone();
            DgElencoMaratone.ItemsSource = elenco.Elenco;
        }
        private void BtnLeggiFile_Click(object sender, RoutedEventArgs e)
        {
            elenco.LeggiDaFile();
            DgElencoMaratone.Items.Refresh();
        }

        private void BtnTempo_Click(object sender, RoutedEventArgs e)
        {
            string Atleta = TxtAtleta.Text;
            string Citta = TxtCitta.Text;
            string TempoTrovato = elenco.CercaAtleta(Atleta,Citta);
            LblTempo.Content = "Il tempo impiegato é "+ TempoTrovato +" minuti";
        }

        private void BtnAtletiPerCitta_Click(object sender, RoutedEventArgs e)
        {
            string Citta = TxtCitta.Text;
            string AtletiTrovati = elenco.AtletiPerCitta(Citta);
            LblAtleti.Content = "Gli atleti partecipanti sono: " + AtletiTrovati;
        }

        private void BtnScriviDaFile_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
