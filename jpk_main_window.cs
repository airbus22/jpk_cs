using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace jpkapp
{
    public partial class jpk_main_window : Form
    {
        public jpk_main_window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public class dbs
        {
            private String connectionString;
            private String OleDBProvider = "Microsoft.JET.OLEDB.4.0";   //if ACE Microsoft.ACE.OLEDB.12.0
            private String OleDBDataSource = "C:\\test.mdb";
            private String OleDBPassword = "infosys";
            private String PersistSecurityInfo = "False";

            public dbs()
            {

            }

            public dbs(String connectionString)
            {
                this.connectionString = connectionString;
            }

            public String konek()
            {
                connectionString = "Provider=" + OleDBProvider + ";Data Source=" + OleDBDataSource + ";JET OLEDB:Database Password=" + OleDBPassword + ";Persist Security Info=" + PersistSecurityInfo + "";
                return connectionString;
            }

        }
    }
}
