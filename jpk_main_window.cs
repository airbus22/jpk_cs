using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace jpkapp
{
    public partial class Jpk_main_window : Form
    {
        MySqlConnection connection, pobierzMAXvalue;
        string ConnectionString = jpkapp.Properties.Settings.Default.ConnectionString;

        public Jpk_main_window()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string zapytanie = "SELECT * FROM jpk_db.stan_fin";
            MySqlDataAdapter da = new MySqlDataAdapter(zapytanie,ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds,"stan_fin");
            ds.WriteXml("jpk_mag.xml", XmlWriteMode.WriteSchema);
            //pobierzMAXvalue = new MySqlConnection(ConnectionString);
            //MySqlCommand zapytanieMAXvalue = new MySqlCommand("SELECT MAX(id_kandydata) FROM web_test_skasowac.rekrutacjaksap", pobierzMAXvalue);
            //zapytanieMAXvalue.Connection.Open();
            //string MAXval_ = zapytanieMAXvalue.ExecuteScalar().ToString();
            //if (MAXval_ == "")
            //    MAXval_ = "0";

            //int MAXval = UInt16.Parse(MAXval_) + 1;    //obliczenie wartości id_kandydata dla kolejnego INSERTa

            //connection = new MySqlConnection(ConnectionString);
            //MySqlCommand zapisz_btn_insert = new MySqlCommand();
            //zapisz_btn_insert.CommandType = System.Data.CommandType.Text;
            //zapisz_btn_insert.CommandText = "INSERT INTO web_test_skasowac.rekrutacjaksap(id_kandydata,dok_plec,dok_imie" + "VALUES (" + MAXval + "," + "'" + dok_plec_ddl.SelectedValue.ToString() + o_kolegiumKSAP_ddl.SelectedValue.ToString() + "'" + "," + "'" + o_zrodloRekKSAP_ddl.SelectedValue.ToString() + "'" + ")";
            
            //zapisz_btn_insert.Connection = connection;
            //connection.Open();
            //zapisz_btn_insert.ExecuteNonQuery();
            //connection.Close();
        }

        public class Dbs
        {
            private String connectionString;
            private String OleDBProvider = "Microsoft.JET.OLEDB.4.0";   //if ACE Microsoft.ACE.OLEDB.12.0
            private String OleDBDataSource = "C:\\test_access2000.mdb";
            private String OleDBPassword = "";
            private String PersistSecurityInfo = "False";

            public Dbs()
            {

            }

            public Dbs(String connectionString)
            {
                this.connectionString = connectionString;
            }

            public String Konek()
            {
                connectionString = "Provider=" + OleDBProvider + ";Data Source=" + OleDBDataSource + ";JET OLEDB:Database Password=" + OleDBPassword + ";Persist Security Info=" + PersistSecurityInfo + "";
                return connectionString;
            }

        }
    }
}
