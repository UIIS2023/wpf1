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
    /// Interaction logic for FrmKartica.xaml
    /// </summary>
    public partial class FrmKartica : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKartica(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtBrojKartice.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmKartica()
        {
            InitializeComponent();
            txtBrojKartice.Focus();
            konekcija = kon.KreirajKonekciju();
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

                string vratiTipoveK = @"Select TipKarticeID, NazivTipaKartice from TipKartice ";

                DataTable dtTipk = new DataTable();
                SqlDataAdapter daTipKartice = new SqlDataAdapter(vratiTipoveK, konekcija);

                daTipKartice.Fill(dtTipk);
                cbTipKartice.ItemsSource = dtKlijent.DefaultView;
                dtTipk.Dispose();
                daTipKartice.Dispose();


            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene.",
                    "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                cmd.Parameters.Add("@brojKartice", SqlDbType.NVarChar).Value = txtBrojKartice.Text;
                cmd.Parameters.Add("@klijentId", SqlDbType.Int).Value = cbKlijent.SelectedValue;
                cmd.Parameters.Add("@tipKarticeId", SqlDbType.Int).Value = cbTipKartice.SelectedValue;

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Kartica set BrojKartice=@brojKartice, KlijentID=@klijentId ,
                                       TipKarticeID = @tipKarticeId where KarticaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Kartica(BrojKartice,KlijentID,TipKarticeID)
                                    values(@nazivTipaKartice,@klijentId,@tipKarticeId)";
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
            Close();
        }
    }

   
}
