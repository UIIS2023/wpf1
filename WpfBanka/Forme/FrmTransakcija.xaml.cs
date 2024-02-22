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
    /// Interaction logic for FrmTransakcija.xaml
    /// </summary>
    public partial class FrmTransakcija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmTransakcija(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtIznosTransakcije.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmTransakcija()
        {
            InitializeComponent();
            txtIznosTransakcije.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                string vratiTrans = @"Select RacunID, BrojRacuna + ' ' + KamatnaStopa as Racun
                                        from Racun";

                DataTable dtTrans = new DataTable();
                SqlDataAdapter daTrans = new SqlDataAdapter(vratiTrans, konekcija);

                daTrans.Fill(dtTrans);
                cbRacun.ItemsSource = dtTrans.DefaultView;
                dtTrans.Dispose();
                daTrans.Dispose();



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
                DateTime dateT = (DateTime)dtDatumTransakcije.SelectedDate;
                string datumTransakcije = dateT.ToString("yyyy-MM-dd");

                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@iznosTransakcije", SqlDbType.NVarChar).Value = txtIznosTransakcije.Text;
                cmd.Parameters.Add("@datumTransakcije", SqlDbType.Date).Value = datumTransakcije;
                cmd.Parameters.Add("@racunId", SqlDbType.Int).Value = cbRacun.SelectedValue;


                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Kredit set IznosTransakcije=@iznosTransakcije,DatumTransakcije=@datumTransakcije, RacunID=@racuntId
                                            where Transakcija=@id";


                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Transakcija(IznosTransakcije,DatumTransakcije,RacunID)
                                    values(@iznosTransakcije, @datumTransakcije,@racunId)";
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
