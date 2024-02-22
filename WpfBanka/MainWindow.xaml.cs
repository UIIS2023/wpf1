using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfBanka.Forme;

namespace WpfBanka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        string ucitanaTabela;

        #region Select upiti
        static string klijentiSelect = @"Select KlijentID as ID,ImeKlijenta,PrezimeKlijenta,AdresaKlijenta,KontaktKlijenta,JMBG as 'JMBG Klijenta',Zaposlenjeklijenta as 'Zaposlenje klijenta' from Klijent";
        static string karticeSelect = @"Select KarticaID as ID,BrojKartice as 'Broj kartice', Klijent.ImeKlijenta + ' ' + Klijent.PrezimeKlijenta as klijent, TipKartice.NazivTipaKartice as 'Naziv tipa kartice' 
                                      from Kartica join Klijent on Kartica.KlijentID=Klijent.KlijentID
                                                   join TipKartice on Kartica.TipKarticeID=TipKartice.TipKarticeID";

        static string korisniciSelect = @"Select KorisnikID as ID, ImeKorisnika, PrezimeKorisnika, AdresaKorisnika, KontaktKorisnika, JMBGkorisnika as 'JMBG Korisnika' from Korisnik ";
        static string kreditiSelect = @"Select KreditID as ID, DatumPodizanjaKredita as 'Datum podizanja kredita' , IznosKredita as 'Ukupan iznos kredita' , ImeKlijenta + ' ' + PrezimeKlijenta as klijent
                                      from Kredit join Klijent on Kredit.KlijentID=Klijent.KlijentID ";

        static string racuniSelect = @"Select RacunID as ID, BrojRacuna as 'Broj računa' , KamatnaStopa as 'Kamatna stopa' , ImeKlijenta + ' ' + PrezimeKlijenta as Klijent,ImeKorisnika + ' ' + PrezimeKorisnika as korisnik,NazivTipaRacuna as 'Naziv tipa računa'
                                     from Racun join Klijent on Racun.KlijentID=Klijent.KlijentID
                                                join Korisnik on Racun.KorisnikID=Korisnik.KorisnikID
                                                join TipRacuna on Racun.TipRacunaID=TipRacuna.TipRacunaID";

        static string rateKreditaSelect = @"Select RataKreditaID as ID, IznosRateKredita as 'Iznos rate kredita', IznosKredita, DatumPodizanjaKredita as kredit
                                          from RataKredita join Kredit on RataKredita.KreditID = Kredit.KreditID ";

        static string tipoviKarticaSelect = @"Select TipKarticeID as ID , NazivTipaKartice as 'Naziv tipa kartice' from TipKartice";
        static string tipoviRacunaSelect = @"Select TipRacunaID as ID, NazivTipaRacuna as 'Naziv tipa računa' from TipRacuna";
        static string transakcijeSelect = @"Select TransakcijaID as ID, DatumTransakcije as 'Datum transakcije' , IznosTransakcije as 'Iznos transakcije' , BrojRacuna,KamatnaStopa as racun
                                          from Transakcija join Racun on Transakcija.RacunID = Racun.RacunID";



        #endregion

        #region Select sa uslovom
        string selectUslovKlijenti = @"Select * from Klijenti where KlijentID=";
        string selectUslovKartice = @"Select * from Kartica where KarticaID=";
        string selectUslovKorisnici = @"Select * from Korisnik where KorisnikID=";
        string selectUslovKrediti = @"Select * from Kredit where KreditID=";
        string selectUslovRacuni = @"Select * from Racun where RacunID=";
        string selectUslovRateKredita = @"Select * from RataKredita where RataKreditaID=";
        string selectUslovTipoviKartica = @"Select * from TipKartice where TipKarticeID=";
        string selectUslovTipoviRacuna = @"Select * from TipRacuna where TipRacunaID=";
        string selectuslovTransakcije = @"Select * from Transakcija where TransakcijaID=";

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(dataGridCentralni, klijentiSelect);

        }

        private void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if(grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Neuspijesno ucitani podaci", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(klijentiSelect))
            {
                prozor = new FrmKlijent();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, klijentiSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                prozor = new FrmRacun();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, racuniSelect);
            }
            else if (ucitanaTabela.Equals(kreditiSelect))
            {
                prozor = new FrmKredit();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, kreditiSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, korisniciSelect);
            }
            else if (ucitanaTabela.Equals(rateKreditaSelect))
            {
                prozor = new FrmRataKredita();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, rateKreditaSelect);
            }
            else if (ucitanaTabela.Equals(tipoviKarticaSelect))
            {
                prozor = new TipKartice();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni,tipoviKarticaSelect);
            }
            else if (ucitanaTabela.Equals(tipoviRacunaSelect))
            {
                prozor = new TipRacuna();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, tipoviRacunaSelect);
            }
            else if (ucitanaTabela.Equals(transakcijeSelect))
            {
                prozor = new FrmTransakcija();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, transakcijeSelect);
            }
            else if (ucitanaTabela.Equals(karticeSelect))
            {
                prozor = new FrmKartica();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, karticeSelect);
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKlijenti_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, klijentiSelect);
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, korisniciSelect);
        }

        private void btnKartice_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, karticeSelect);
        }

        private void btnKrediti_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, kreditiSelect);
        }

        private void btnRacuni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, racuniSelect);
        }

        private void btnRateKredita_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, rateKreditaSelect);
        }

        private void btnTipoviKartica_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, tipoviKarticaSelect);
        }

        private void btnTipoviRacuna_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, tipoviRacunaSelect);
        }

        private void btnTransakcije_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, transakcijeSelect);
        }
    }
}
