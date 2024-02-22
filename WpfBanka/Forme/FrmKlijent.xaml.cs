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
    /// Interaction logic for FrmKlijent.xaml
    /// </summary>
    public partial class FrmKlijent : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKlijent(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtImeKlijenta.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKlijent()
        {
            InitializeComponent();
            txtImeKlijenta.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@imeKlijenta", SqlDbType.NVarChar).Value = txtImeKlijenta.Text;
                cmd.Parameters.Add("@prezimeKlijenta", SqlDbType.NVarChar).Value = txtPrezimeKlijenta.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NVarChar).Value = txtJMBGKlijenta.Text;
                cmd.Parameters.Add("@adresaKlijenta", SqlDbType.NVarChar).Value = txtAdresaKlijenta.Text;
                cmd.Parameters.Add("@zaposlenjeKlijenta", SqlDbType.NVarChar).Value = txtZaposlenjeKlijenta.Text;
                cmd.Parameters.Add("@kontaktKlijenta", SqlDbType.NVarChar).Value = txtKontaktKlijenta.Text;
                if (azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Klijent
                                            set ImeKlijenta=@imeKlijenta, PrezimeKlijenta=@prezimeKlijenta, Jmbg=@jmbg, AdresaKlijenta=@adresaKlijenta, ZaposlenjeKlijenta=@zaposlenjeKlijenta, KontaktKlijenta=@kontaktKlijenta
                                            where KlijentID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Klijent(ImeKlijenta, PrezimeKlijenta, Jmbg, AdresaKlijenta, ZaposlenjeKlijenta, KontaktKlijenta)
                                    values(@imeKlijenta, @prezimeKlijenta, @jmbg, @adresaKlijenta, @zaposlenjeKlijenta, @kontaktKlijenta)";

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

  
        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
