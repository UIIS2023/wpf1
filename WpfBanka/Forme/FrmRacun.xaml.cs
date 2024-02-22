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
using System.Windows.Shapes;

namespace WpfBanka.Forme
{

    public partial class FrmRacun : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmRacun(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtBrojRacuna.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }

        public FrmRacun()
        {
            InitializeComponent();
            txtBrojRacuna.Focus();
            PopuniPadajuceListe();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                string vratiKlijente = @"Select KlijentID, ImeKlijenta + ' ' + PrezimeKlijenta as Klijent
                                        from Klijent";

                DataTable dtKlijent = new DataTable();
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijente, konekcija);

                daKlijent.Fill(dtKlijent);
                cbKlijent.ItemsSource = dtKlijent.DefaultView;
                dtKlijent.Dispose();
                daKlijent.Dispose();

                string vratiKorisnike = @"Select KorisnikID, ImeKorisnika + ' ' + PrezimeKorisnika as Korisnik
                                        from Korisnik";

                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);

                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();

                string vratiTipoveRacuna = @"Select TipRacunaID, NazivTipaRacuna as tip
                                        from TipRacun";

                DataTable dtTipR = new DataTable();
                SqlDataAdapter daTipR = new SqlDataAdapter(vratiTipoveRacuna, konekcija);

                daTipR.Fill(dtTipR);
                cbTipRacuna.ItemsSource = dtTipR.DefaultView;
                dtTipR.Dispose();
                daTipR.Dispose();


            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene.",
                    "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();


                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@brojRacuna", SqlDbType.NVarChar).Value = txtBrojRacuna.Text;
                cmd.Parameters.Add("@kamatnaStopa", SqlDbType.NVarChar).Value = txtKamatnaStopa.Text;

                cmd.Parameters.Add("@klijentId", SqlDbType.Int).Value = cbKlijent.SelectedValue;
                cmd.Parameters.Add("@korisnikId", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@tipRacunaId", SqlDbType.Int).Value = cbTipRacuna.SelectedValue;
                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Racun
                                        set BrojRacuna=@brojRacuna, KamatnaStopa=@kamatnaStopa,KlijentID=@klijentId, KorisnikID=@korisnikId, TipRacuna=@tipRacunaId
                                        where RegistracijaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Racun(BrojRacuna,KamatnaStopa,KlijentID,KorisnikID,TipRacunaID)
                                    values(@brojRacuna,@kamatnaStopa, @klijentId,@korisnikId, @tipRacunaId,)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greška prilikom konverzije podataka!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija?.Close();
            }
        }



        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
