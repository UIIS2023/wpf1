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
    /// Interaction logic for FrmKredit.xaml
    /// </summary>
    public partial class FrmKredit : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKredit(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtIznosKredita.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKredit()
        {
            InitializeComponent();
            txtIznosKredita.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        

        private void btnOtkaži_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                DateTime date = (DateTime)dtDatumKredita.SelectedDate;
                string datumPodizanjaKredita = date.ToString("yyyy-MM-dd");

                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@iznosKredita", SqlDbType.NVarChar).Value = txtIznosKredita.Text;
                cmd.Parameters.Add("@datumPodizanjaKredita", SqlDbType.Date).Value = datumPodizanjaKredita;
                cmd.Parameters.Add("@klijentId", SqlDbType.Int).Value = cbKlijent.SelectedValue;


                if (azuriraj)
                {
                    DataRowView red = pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Kredit set IznosKredita=@IznosKredita,DatumPodizanjaKredita=@datumPodizanjaKredita, KlijentID=@klijentId
                                            where Kredit=@id";
                   

                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Kredit(IznosKredita,DatumPodizanjaKredita,KlijentID)
                                    values(@iznosKredita, @datumPodizanjaKredita,@klijentId)";
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
    }
    }

