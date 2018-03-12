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
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace jpkapp
{
    public partial class Jpk_main_window : Form
    {
        static string ConnectionString = jpkapp.Properties.Settings.Default.ConnectionString;
        //static string zapytanie = "SELECT * FROM jpk_db.operacje WHERE id_oper>=34130 AND id_oper<=34150";     //baza MySQL
        static string zapytanie = "SELECT * FROM jpk_db.operacje WHERE id_oper>=34388 AND id_oper<=34409";     //baza MySQL - zakres pełniejszy
        //static string zapytanie = "SELECT* FROM jpk_db.operacje WHERE id_oper=34130";   //dla RW
        //static string zapytanie = "SELECT* FROM jpk_db.operacje WHERE id_oper=34135";   //dla PZ
        //static string zapytanie = "SELECT * FROM jpk_db.operacje";
        string lokalizacjaPlikuXML = @"D:\jpk_mag.xml";
        FileInfo InformacjaOPliku = new FileInfo("D:\\jpk_mag.xml");

        string XML_linia1 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        string XML_linia2 = "<JPK xmlns:etd=\"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2016/01/25/eD/DefinicjeTypy/\" xmlns:kck=\"http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2013/05/23/eD/KodyCECHKRAJOW/\" xmlns=\"http://jpk.mf.gov.pl/wzor/2016/10/26/10261/\">";
        string XML_linia3 = "      <Naglowek>";
        string XML_linia4 = "            <KodFormularza kodSystemowy=”JPK_MAG (1)” wersjaSchemy=”1-0″>JPK_MAG</KodFormularza>";
        string XML_linia5 = "            <WariantFormularza>2</WariantFormularza>";
        string XML_linia6 = "            <CelZlozenia>1</CelZlozenia>";
        string XML_linia7 = "            <DataWytworzeniaJPK>" + DateTime.Now.ToString() + "2017-08-16T13:32:46</DataWytworzeniaJPK>";
        string XML_linia8 = "            <DataOd>2018-07-01</DataOd>";
        string XML_linia9 = "            <DataDo>2018-07-31</DataDo>";
        string XML_linia10 = "            <DomyslnyKodWaluty>PLN</DomyslnyKodWaluty>";
        string XML_linia11 = "            <KodUrzedu>1449</KodUrzedu>";
        string XML_linia12 = "      </Naglowek>";
        string XML_linia13 = "      <Podmiot1>";
        string XML_linia14 = "            <IdentyfikatorPodmiotu>";
        string XML_linia15 = "                  <etd:NIP>5250006124</etd:NIP>";
        string XML_linia16 = "                  <etd:PelnaNazwa>KRAJOWA SZKOŁA ADMINISTRACJI PUBLICZNEJ im.Prezydenta Rzeczypospolitej Polskiej Lecha Kaczyńskiego</etd:PelnaNazwa>";
        string XML_linia17 = "                  <etd:REGON>006472421</etd:REGON>";
        string XML_linia18 = "            </IdentyfikatorPodmiotu>";
        string XML_linia19 = "            <AdresPodmiotu>";
        string XML_linia20 = "                  <KodKraju>PL</KodKraju>";
        string XML_linia21 = "                  <Wojewodztwo>mazowieckie</Wojewodztwo>";
        string XML_linia22 = "                  <Powiat>WARSZAWSKI</Powiat>";
        string XML_linia23 = "                  <Gmina>CENTRUM</Gmina>";
        string XML_linia24 = "                  <Ulica>WAWELSKA</Ulica>";
        string XML_linia25 = "                  <NrDomu>56</NrDomu>";
        string XML_linia26 = "                  <Miejscowosc>WARSZAWA</Miejscowosc>";
        string XML_linia27 = "                  <KodPocztowy>00-922</KodPocztowy>";
        string XML_linia28 = "                  <Poczta>WARSZAWA</Poczta>";
        string XML_linia29 = "            </AdresPodmiotu>";
        string XML_linia30 = "      </Podmiot1>";
        string XML_linia31 = "      <Magazyn>1</Magazyn>";

        public Jpk_main_window()
        {
            InitializeComponent();

            komunikaty_lbl.Text = "Gotowe";

            FormBorderStyle = FormBorderStyle.FixedSingle;

            DTP_poczatkowa.Format = DateTimePickerFormat.Custom;
            DTP_poczatkowa.CustomFormat = "dd-MM-yyyy";

            DTP_koncowa.Format = DateTimePickerFormat.Custom;
            DTP_koncowa.CustomFormat = "dd-MM-yyyy";
        }
                
        public void GeneruPlikXML(DataTable dt, string filePath)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(filePath, true);
            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                
                if (array[2].ToString().Contains("RW") || array[2].ToString().Contains("Rw") || array[2].ToString().Contains("rW") || array[2].ToString().Contains("rw"))
                {
                    sw.Write("      <RW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <RWWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NumerRW>" + (array[2].ToString()).Substring(3) + "</NumerRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataRW>" + (array[11].ToString()).Substring(0,10) + "</DataRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscRW>-" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</WartoscRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataWydaniaRW>" + (array[11].ToString()).Substring(0, 10) + "</DataWydaniaRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </RWWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <RWWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <Numer2RW>" + (array[2].ToString()).Substring(3) + "</Numer2RW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <KodTowaruRW>" + array[3].ToString() + "</KodTowaruRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NazwaTowaruRW>" + array[4].ToString() + "</NazwaTowaruRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <IloscWydanaRW>-" + array[7].ToString() + "</IloscWydanaRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <JednostkaMiaryRW>" + (array[5].ToString()).Substring(0, (array[5].ToString()).IndexOf(".")).ToUpper() + "</JednostkaMiaryRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <CenaJednRW>" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",",".") + "</CenaJednRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscPozycjiRW>-" + (Double.Parse(array[7].ToString()))*Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</WartoscPozycjiRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </RWWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <RWCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <LiczbaRW>" + "1" + "</LiczbaRW>", FileMode.Append);    //co to znaczy!!!! i dalej dla PZ, MM, WZ....
                    sw.WriteLine();
                    sw.Write("                  <SumaRW>-" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</SumaRW>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </RWCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("      </RW>", FileMode.Append);
                }

                else if (array[2].ToString().Contains("PZ") || array[2].ToString().Contains("Pz") || array[2].ToString().Contains("pZ") || array[2].ToString().Contains("pz"))
                {
                    sw.Write("      <PZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <PZWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NumerPZ>" + (array[2].ToString()).Substring(3) + "</NumerPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataPZ>" + (array[11].ToString()).Substring(0, 10) + "</DataPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscPZ>" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</WartoscPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataWydaniaPZ>" + (array[11].ToString()).Substring(0, 10) + "</DataWydaniaPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </PZWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <PZWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <Numer2PZ>" + (array[2].ToString()).Substring(3) + "</Numer2PZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <KodTowaruPZ>" + array[3].ToString() + "</KodTowaruPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NazwaTowaruPZ>" + array[4].ToString() + "</NazwaTowaruPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <IloscWydanaPZ>" + array[7].ToString() + "</IloscWydanaPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <JednostkaMiaryPZ>" + (array[5].ToString()).Substring(0, (array[5].ToString()).IndexOf(".")).ToUpper() + "</JednostkaMiaryPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <CenaJednPZ>" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</CenaJednPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscPozycjiPZ>" + (Double.Parse(array[7].ToString()))*Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</WartoscPozycjiPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </PZWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <PZCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <LiczbaPZ>" + "1" + "</LiczbaPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <SumaPZ>" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</SumaPZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </PZCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("      </PZ>", FileMode.Append);
                }

                else if (array[2].ToString().Contains("MM") || array[2].ToString().Contains("Mm") || array[2].ToString().Contains("mM") || array[2].ToString().Contains("mm"))
                {
                    sw.Write("      <MM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <MMWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NumerMM>" + (array[2].ToString()).Substring(3) + "</NumerMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataMM>" + (array[11].ToString()).Substring(0, 10) + "</DataMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscMM>-" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</WartoscMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataWydaniaMM>" + (array[11].ToString()).Substring(0, 10) + "</DataWydaniaMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <SkadMM>" + (array[2].ToString()).Substring(3) + "</SkadMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DokadMM>" + (array[2].ToString()).Substring(3) + "</DokadMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </MMWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <MMWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <Numer2MM>" + (array[2].ToString()).Substring(3) + "</Numer2MM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <KodTowaruMM>" + array[3].ToString() + "</KodTowaruMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NazwaTowaruMM>" + array[4].ToString() + "</NazwaTowaruMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <IloscWydanaMM>-" + array[7].ToString() + "</IloscWydanaMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <JednostkaMiaryMM>" + (array[5].ToString()).Substring(0, (array[5].ToString()).IndexOf(".")).ToUpper() + "</JednostkaMiaryMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <CenaJednMM>" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</CenaJednMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscPozycjiMM>-" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</WartoscPozycjiMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </MMWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <MMCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <LiczbaMM>" + "1" + "</LiczbaMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <SumaMM>-" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</SumaMM>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </MMCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("      </MM>", FileMode.Append);
                }

                else if (array[2].ToString().Contains("WZ") || array[2].ToString().Contains("Wz") || array[2].ToString().Contains("wZ") || array[2].ToString().Contains("wz"))
                {
                    sw.Write("      <WZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <WZWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NumerWZ>" + (array[2].ToString()).Substring(3) + "</NumerWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataWZ>" + (array[11].ToString()).Substring(0, 10) + "</DataWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscWZ>-" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</WartoscWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <DataWydaniaWZ>" + (array[11].ToString()).Substring(0, 10) + "</DataWydaniaWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </WZWWartosc>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <WZWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <Numer2WZ>" + (array[2].ToString()).Substring(3) + "</Numer2WZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <KodTowaruWZ>" + array[3].ToString() + "</KodTowaruWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <NazwaTowaruWZ>" + array[4].ToString() + "</NazwaTowaruWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <IloscWydanaWZ>-" + array[7].ToString() + "</IloscWydanaWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <JednostkaMiaryWZ>" + (array[5].ToString()).Substring(0, (array[5].ToString()).IndexOf(".")).ToUpper() + "</JednostkaMiaryWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <CenaJednWZ>" + (array[6].ToString()).Substring(0, array[6].ToString().Length - 3).Replace(",", ".") + "</CenaJednWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <WartoscPozycjiWZ>-" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</WartoscPozycjiWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </WZWiersz>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            <WZCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <LiczbaWZ>" + "1" + "</LiczbaWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("                  <SumaWZ>-" + (Double.Parse(array[7].ToString())) * Convert.ToDouble(((array[6].ToString()).Substring(0, array[6].ToString().Length - 3))) + "</SumaWZ>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("            </WZCtrl>", FileMode.Append);
                    sw.WriteLine();
                    sw.Write("      </WZ>", FileMode.Append);
                }

                else
                {
                    sw.Write("      <* * * BłędnaWartość * * *>" + array[2].ToString() + "</* * * BłędnaWartość * * *>", FileMode.Append);
                }
                
                sw.WriteLine();
            }
            sw.Write("</JPK>", FileMode.Append);
            sw.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(lokalizacjaPlikuXML))
            {
                File.Delete(lokalizacjaPlikuXML);
            }

            try
            {
                StreamWriter plikXML = new StreamWriter(@"D:\jpk_mag.xml", true);   //wpisywanie do pliku linia po linii
                //for (int i = 1; i <= 31; i++)
                //{                    
                //    string s = "XML_linia" + i.ToString();
                //    //Type NazwaZmiennej = this.GetType();
                //    //MethodInfo Info = NazwaZmiennej.GetMethod(s);
                //    MethodInfo Info = this.GetType().GetMethod(s);
                //    Info.Invoke(s,null);
                //    //plikXML.WriteLine(s);                    
                //}


                plikXML.WriteLine(XML_linia1);
                plikXML.WriteLine(XML_linia2);
                plikXML.WriteLine(XML_linia3);
                plikXML.WriteLine(XML_linia4);
                plikXML.WriteLine(XML_linia5);
                plikXML.WriteLine(XML_linia6);
                plikXML.WriteLine(XML_linia7);
                plikXML.WriteLine(XML_linia8);
                plikXML.WriteLine(XML_linia9);
                plikXML.WriteLine(XML_linia10);
                plikXML.WriteLine(XML_linia11);
                plikXML.WriteLine(XML_linia12);
                plikXML.WriteLine(XML_linia13);
                plikXML.WriteLine(XML_linia14);
                plikXML.WriteLine(XML_linia15);
                plikXML.WriteLine(XML_linia16);
                plikXML.WriteLine(XML_linia17);
                plikXML.WriteLine(XML_linia18);
                plikXML.WriteLine(XML_linia19);
                plikXML.WriteLine(XML_linia20);
                plikXML.WriteLine(XML_linia21);
                plikXML.WriteLine(XML_linia22);
                plikXML.WriteLine(XML_linia23);
                plikXML.WriteLine(XML_linia24);
                plikXML.WriteLine(XML_linia25);
                plikXML.WriteLine(XML_linia26);
                plikXML.WriteLine(XML_linia27);
                plikXML.WriteLine(XML_linia28);
                plikXML.WriteLine(XML_linia29);
                plikXML.WriteLine(XML_linia30);
                plikXML.WriteLine(XML_linia31);
                plikXML.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

            finally
            {
                komunikaty_lbl.Text = "Generowanie nagłówka pliku JPK";
            }

            //**** MySQL działa**********************************************************

            MySqlDataAdapter da = new MySqlDataAdapter(zapytanie, ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "operacje");
            //ds.WriteXml(lokalizacjaPlikuXML, XmlWriteMode.WriteSchema);
            komunikaty_lbl.Text = "Pobieranie danych z magazynu...";

            try
            {
                GeneruPlikXML(ds.Tables["operacje"], lokalizacjaPlikuXML);
            }

            catch (Exception ConnEX)
            {
                MessageBox.Show(ConnEX.ToString());
            }

            finally
            {
                //connection.Close();
                komunikaty_lbl.Text = "Pomyślnie zakończono genetowanie pliku w lokalizacji C:\\TEMP\\JPK_MAG\\";
            }

            //**************************************************************************

            //**** MS Access DB działa**********************************************************
            ////Microsoft.ACE.OLEDB.12.0
            ////Microsoft.Jet.OLEDB.4.0
            //string accessConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            ////string accessConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //               "Data Source=C:\\TEMP\\test_access2000.mdb;" +
            //               //"Data Source=C:\\TEMP\\ksapbefg.mdb;" +
            //               //"Trusted_Connection=yes";
            //               //"Integrated Security=SSPI";
            //               "Persist Security Info=True;" +
            //               "Jet OLEDB:User ID=wt;" +
            //               "Jet OLEDB:Database Password=;";
            //try
            //{
            //    // Open OleDb Connection
            //    OleDbConnection access_cn = new OleDbConnection();
            //    //{
            //    //    ConnectionString = accessConnectionString;
            //    //}
            //    access_cn.ConnectionString = accessConnectionString;
            //    access_cn.Open();

            //    // Execute Queries
            //    OleDbCommand cmd = access_cn.CreateCommand();
            //    cmd.CommandText = "SELECT * FROM `operacje`";
            //    OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // close conn after complete

            //    // Load the result into a DataTable
            //    DataTable myDataTable = new DataTable();
            //    myDataTable.Load(reader);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("OLEDB Connection FAILED: " + ex.Message);
            //}

            //**************************************************************************
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}