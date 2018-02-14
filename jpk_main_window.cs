﻿using System;
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
        static string ConnectionString = jpkapp.Properties.Settings.Default.ConnectionString;
        static string zapytanie = "SELECT * FROM jpk_db.operacje WHERE id_oper>=34130 AND id_oper<=34150";     //baza MySQL
        //static string zapytanie = "SELECT * FROM jpk_db.operacje";
        //string nazwaPlikuXML = "jpk_mag.xml";
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

        public Jpk_main_window()
        {
            InitializeComponent();            
        }
                
        public void Write(DataTable dt, string filePath)
        {
            //int i = 0;
            StreamWriter sw = null;
            sw = new StreamWriter(filePath, true);
            //for (i = 0; i < dt.Columns.Count - 1; i++)
            //{
            //    sw.Write(dt.Columns[i].ColumnName + " ");
            //}
            //sw.Write(dt.Columns[i].ColumnName);
            //sw.WriteLine();
            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;

                if (array[2].ToString().Contains("RW") || array[2].ToString().Contains("Rw") || array[2].ToString().Contains("rW") || array[2].ToString().Contains("rw"))
                {
                    sw.Write("      <ElementMagazynu>" + array[2].ToString() + "<\\ElementMagazynu>", FileMode.Append);
                }

                else if (array[2].ToString().Contains("PZ") || array[2].ToString().Contains("Pz") || array[2].ToString().Contains("pZ") || array[2].ToString().Contains("pz"))
                {
                    sw.Write("      <ElementMagazynu>" + array[2].ToString() + "<\\ElementMagazynu>", FileMode.Append);
                }

                else if (array[2].ToString().Contains("MM") || array[2].ToString().Contains("Mm") || array[2].ToString().Contains("mM") || array[2].ToString().Contains("mm"))
                {
                    sw.Write("      <ElementMagazynu>" + array[2].ToString() + "<\\ElementMagazynu>", FileMode.Append);
                }

                else
                {
                    sw.Write("      <* * * BłędnaWartość * * *>" + array[2].ToString() + "<\\* * * BłędnaWartość * * *>", FileMode.Append);
                }

                //for (i = 0; i < array.Length - 1; i++)
                //{
                //    sw.Write(array[i] + " ");
                //}
                //sw.Write(array[i].ToString());
                sw.WriteLine();
            }
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
                plikXML.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

            //finally
            //{

            //}

            MySqlDataAdapter da = new MySqlDataAdapter(zapytanie, ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "operacje");
            //ds.WriteXml(lokalizacjaPlikuXML, XmlWriteMode.WriteSchema);

            try
            {
                Write(ds.Tables["operacje"], lokalizacjaPlikuXML);

                //int i = 0;
                //StreamWriter sw = null;
                //sw = new StreamWriter(lokalizacjaPlikuXML, false);
                ////for (i = 0; i < dt.Columns.Count - 1; i++)
                ////{
                ////    sw.Write(dt.Columns[i].ColumnName + " ");
                ////}
                ////sw.Write(dt.Columns[i].ColumnName);
                ////sw.WriteLine();
                //foreach (DataRow row in dt.Rows)
                //{
                //    object[] array = row.ItemArray;
                //    if (array[2].ToString().Contains("Rw"))
                //        sw.Write("<ElementMagazynu>" + array[2].ToString() + "<\\ElementMagazynu>", FileMode.Append);
                //    //for (i = 0; i < array.Length - 1; i++)
                //    //{
                //    //    sw.Write(array[i] + " ");
                //    //}
                //    //sw.Write(array[i].ToString());
                //    sw.WriteLine();
                //}
                //sw.Close();


                //    //StreamWriter plikXML = new StreamWriter(@"D:\jpk_mag.xml", true);
                //    //foreach (DataRow row in ds.Tables["operacje"].Rows)
                //    //{
                //    //    foreach (object item in row.ItemArray)
                //    //    {
                //    //        plikXML.Write(item + "\t");
                //    //    }
                //    //    plikXML.WriteLine();
                //    //}

                //    ////connection.Open();
                //    //da.Fill(ds, "operacje");
                //    //StreamWriter plikXML = new StreamWriter(@"D:\jpk_mag.xml", true);   //wpisywanie do pliku linia po linii
                //    //foreach (DataTable table in ds.Tables)
                //    //{
                //    //    foreach (DataRow dr in table.Rows)
                //    //    {
                //    //        var dok_pz_rw = dr["dok_pz_rw"].ToString();

                //    //        //plikXML.WriteLine("  <Test> " + plikXML + "  </Test> ");
                //    //        plikXML.WriteLine("  <Test> </Test> ");
                //    //    }
                //    //}
            }

            catch (Exception ConnEX)
            {
                MessageBox.Show(ConnEX.ToString());
            }

            finally
            {
                //connection.Close();
            }

        }

        //public class Dbs
        //{
        //    private String connectionString;
        //    private String OleDBProvider = "Microsoft.JET.OLEDB.4.0";   //if ACE Microsoft.ACE.OLEDB.12.0
        //    private String OleDBDataSource = "C:\\test_access2000.mdb";
        //    private String OleDBPassword = "";
        //    private String PersistSecurityInfo = "False";

        //    public Dbs()
        //    {

        //    }

        //    public Dbs(String connectionString)
        //    {
        //        this.connectionString = connectionString;
        //    }

        //    public String Konek()
        //    {
        //        connectionString = "Provider=" + OleDBProvider + ";Data Source=" + OleDBDataSource + ";JET OLEDB:Database Password=" + OleDBPassword + ";Persist Security Info=" + PersistSecurityInfo + "";
        //        return connectionString;
        //    }

        //}
    }
}