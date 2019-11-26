using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static MVC_CORE.Models.Model_clienti;

namespace MVC_CORE.Models
{
    public class Verificare
    {
        public static string ConnectionString = "server = localhost; port = 3306; database = test; user = root; password = root";
        public static bool ok = false;
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public static void Verificari(Model_clienti m)
        {
            string fail = null;
            fail = Verificare_nume(m.Nume);
            fail = Verificare_prenume(m.Prenume);
            fail = Verificare_camera(m.tip_camera,m.check_in,m.check_out);
            fail = Verificare_carte_credit(m.carte_de_credit,m.numar_carte,m.Data_expirarii,m.CCV);
            m.fail = fail;
        }
        private static string Verificare_nume(string nume)
        {
            if (nume == null)
            {
                return "Nume necompletat";
            }
            else
            {
                return null;
            }
        }
        private static string Verificare_prenume(string prenume)
        {
            if (prenume == null)
            {
                return "Prenume necompletat";
            }
            else
            {
                return null;
            }
        }
        public static string Verificare_camera(Tip_camera t)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "select "+t.ToString()+" from Camere;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere = dTable.AsEnumerable().ToList();
            foreach (DataRow stare_camere in list_camere)
            {
                if (stare_camere.ItemArray[0].ToString() == "liber curat")
                {
                    return null;
                }
            }
            return "incercati alt tip de camera";
        }
        private static string Verificare_camera(Tip_camera t, DateTime check_in, DateTime check_out)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "select " + t.ToString() + " from Camere;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere = dTable.AsEnumerable().ToList();
            foreach (DataRow stare_camere in list_camere)
            {
                if (stare_camere.ItemArray[0].ToString() == "liber curat")
                {
                    return Verificare_date_valabile(check_in, check_out, t);
                }
            }

            return "nu mai sunt camere de acest tip";
        }
        private static string Verificare_date_valabile(DateTime check_in,DateTime check_out, Tip_camera t)
        {
            int ok1=0,a,b,c,d,e,f;
            string valabil = "ceva";
            int zi_in = int.Parse(check_in.ToString().Substring(0, 2)), zi_out = int.Parse(check_out.ToString().Substring(0, 2));
            int luna_in = int.Parse(check_in.ToString().Substring(3, 2)), luna_out = int.Parse(check_out.ToString().Substring(3, 2));
            int an_in = int.Parse(check_in.ToString().Substring(6, 4)), an_out = int.Parse(check_out.ToString().Substring(6, 4));
            if (ok)
            {
                return null;
            }
            if(an_in>an_out || luna_in>luna_out || zi_in > zi_out)
            {
                return "invalid date-time";
            }
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query1 = "select Check_IN,Check_OUT from Tabel_clienti WHERE Tip_camera='"+t.ToString()+"';";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            MySqlDataAdapter adapt1 = new MySqlDataAdapter();
            adapt1.SelectCommand = cmd1;
            DataTable dTable1 = new DataTable();
            adapt1.Fill(dTable1);
            List<DataRow> list_data_check = dTable1.AsEnumerable().ToList();
            foreach (DataRow data in list_data_check)
            {
                a = int.Parse(data.ItemArray[0].ToString().Substring(6, 4));//an in
                b = int.Parse(data.ItemArray[1].ToString().Substring(6, 4));//an out
                c = int.Parse(data.ItemArray[0].ToString().Substring(3, 2));//luna in
                d = int.Parse(data.ItemArray[1].ToString().Substring(3, 2));//luna out
                e = int.Parse(data.ItemArray[0].ToString().Substring(0, 2));//zi in
                f = int.Parse(data.ItemArray[1].ToString().Substring(0, 2));//zi out

                if ((a < an_in &&  an_in< b) || (a < an_out && an_out < b) || (an_in<a && b<an_out))
                    valabil = "data nu este disponibila";
                else
                {
                    if ((c < luna_in && luna_in < d) || (c < luna_out && luna_out < d) || (luna_in < c && d < luna_out))
                        valabil = "data nu este disponibila";
                    else
                    {
                        if ((e < zi_in && zi_in < f) || (e < zi_out && zi_out < f) || (zi_in < e && f < zi_out))
                            valabil = "data nu este disponibila";
                        else
                            ok1++;
                    }
                }
                    
            }
            if (ok1 == list_data_check.Count())
            {
                valabil = null;
            }
            return valabil;
        }
        private static string Verificare_carte_credit(Carte_de_credit c,string numar_carte,string data_exp,string ccv)
        {
            return null;
        }

    }
}
