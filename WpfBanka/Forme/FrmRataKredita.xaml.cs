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
    /// Interaction logic for FrmRataKredita.xaml
    /// </summary>
    public partial class FrmRataKredita : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmRataKredita(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtIznosRateKredita.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmRataKredita()
        {
            InitializeComponent();
            txtIznosRateKredita.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                string vratiRate = @"Select KreditID, IznosKredita, DatumPodizanjaKredita as Kredit
                                        from Kredit";

                DataTable dtRata = new DataTable();
                SqlDataAdapter daRata = new SqlDataAdapter(vratiRate, konekcija);

                daRata.Fill(dtRata);
                cbKredit.ItemsSource = dtRata.DefaultView;
                dtRata.Dispose();
                daRata.Dispose();

                

              


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
                cmd.Parameters.Add("@iznosRateKredita", SqlDbType.NVarChar).Value = txtIznosRateKredita.Text;
                cmd.Parameters.Add("@kreditId", SqlDbType.Int).Value = cbKredit.SelectedValue;
                

                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update RataKredita set IznosRateKredita=@iznosRateKredita, KreditID=@kreditId ,
                                       where RataKreditaID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into RataKredita(IznosRateKredita,KreditID)
                                    values(@iznosRateKredita,@kreditId)";
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

        }
    }
}
