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
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKorisnik(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            konekcija = kon.KreirajKonekciju();
        }
       
        private void btnSačuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@imeKorisnika", SqlDbType.NVarChar).Value = txtImeKorisnika.Text;
                cmd.Parameters.Add("@prezimeKorisnika", SqlDbType.NVarChar).Value = txtPrezimeKorisnika.Text;
                cmd.Parameters.Add("@jmbgkorisnika", SqlDbType.NVarChar).Value = txtJMBGKorisnika.Text;
                cmd.Parameters.Add("@adresaKorisnika", SqlDbType.NVarChar).Value = txtAdresaKorisnika.Text;
               
                cmd.Parameters.Add("@kontaktKorisnika", SqlDbType.Int).Value = txtKontaktKorisnika.Text;
                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Korisnik
                                            set ImeKorisnika=@imeKorisnika, PrezimeKorisnika=@prezimeKorisnika, JMBGkorisnika=@jmbgkorisnika, AdresaKorisnika=@adresaKorisnika, 
                                               KontaktKorisnika=@kontaktKorisnika
                                            where KorisnikID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Korisnik(ImeKorisnika, PrezimeKorisnika, JMBGkorisnika, AdresaKorisnika, KontaktKorisnika)
                                    values(@imeKorisnika, @prezimeKorisnika, @jmbgkorisnika, @adresaKorisnika, @kontaktKorisnika)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija?.Close();
            }
        }

        private void btnOtkaži_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
}
