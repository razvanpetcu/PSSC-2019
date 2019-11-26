using MVC_CORE.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static MVC_CORE.Models.Model_clienti;

namespace MVC_CORE.Repository
{
    public class Repository_clienti
    {
        private static string ConnectionString = "server = localhost; port = 3306; database = test; user = root; password = root";
        static int numar_confirmare = 0;
        private static List<Model_clienti> lista_clienti = new List<Model_clienti>();
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public static string Insert(Model_clienti m)
        {
            if (First(m))
            {
                return null;
            }
            else
            {
                numar_confirmare = maxim()+1;
                Verif(m);
                if (m.fail == null)
                {
                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();
                        string query;
                        query = "INSERT into Tabel_clienti VALUES('" + numar_confirmare.ToString() + "','" + m.Nume + "','" + m.Prenume + "','"
                            + m.tip_camera.ToString() + "','" + m.check_in.ToString() + "','" + m.check_out.ToString() + "','" + m.carte_de_credit.ToString()
                            + "','" + m.numar_carte + "','" + m.Data_expirarii + "','" + m.CCV + "','" + m.Mentiuni + "');";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader myreader;
                        
                        myreader = cmd.ExecuteReader();//EXECUTE QUERY
                        Repository_camere.Update_camera(m.tip_camera);
                        Actualizare_lista();

                        Verificare.ok = false;
                    }
                }
            }
            return m.fail;
        }

        public static string Update(Model_clienti m)
        {
            Verif(m);
            if (m.fail == null)
            {
                //cautare client
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query;
                    query = "UPDATE tabel_clienti SET Nume='" + m.Nume + "',Prenume='" + m.Prenume + "',Tip_camera='" + m.tip_camera.ToString() + "'" +
                        ",Check_IN='" + m.check_in.ToString() + "',Check_OUT='" + m.check_out.ToString() + "',Carte_Credit='" + m.carte_de_credit.ToString() + "'" +
                        ",Numar_Carte='" + m.numar_carte + "',Data_expirare='" + m.Data_expirarii + "',CCV='" + m.CCV + "',Mentiuni='" + m.Mentiuni + "' WHERE ID='" + m.ID + "';";
                    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY
                    Repository_camere.Update_camera(m.tip_camera);
                    Actualizare_lista();

                    Verificare.ok = false;
                }
            }
            return null;
        }

        private static void Verif(Model_clienti m)
        {
            Verificare.Verificari(m);
        }
        private static bool First(Model_clienti m)
        {
            
            if (Verificare.ok)
            {
                numar_confirmare++;
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query,query1;
                    query = "INSERT into Tabel_clienti VALUES('" + numar_confirmare.ToString() + "','" + m.Nume + "','" + m.Prenume + "','"
                        + m.tip_camera.ToString() + "','" + m.check_in.ToString() + "','" + m.check_out.ToString() + "','" + m.carte_de_credit.ToString()
                        + "','" + m.numar_carte + "','" + m.Data_expirarii + "','" + m.CCV + "','" + m.Mentiuni + "');";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY
                    Repository_camere.Update_camera(m.tip_camera);
                    Actualizare_lista();

                    Verificare.ok = false;
                    return true;
                }
            }
            return false;
        }
        private static int maxim()
        {
            int a;
            //cautare baza de date numarul cel mai mare
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "SELECT ID FROM tabel_clienti;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere = dTable.AsEnumerable().ToList();
            foreach (DataRow id in list_camere)
            {
                a = int.Parse(id.ItemArray[0].ToString());
                if (a>numar_confirmare)
                {
                    numar_confirmare = a;
                }
            }
            return numar_confirmare;
        }
        public static Model_clienti Cautare_client(int id)
        {
            foreach(Model_clienti m in lista_clienti)
            {
                if (m.ID == id)
                {
                    return m;
                }
            }
            return null;
        }
        public static void Actualizare_lista()
        {
            lista_clienti.Clear();
            Model_clienti m=null;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "SELECT * FROM tabel_clienti;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere = dTable.AsEnumerable().ToList();
            foreach (DataRow id in list_camere)
            {
                m.ID = int.Parse(id.ItemArray[0].ToString());
                m.Nume = id.ItemArray[1].ToString();
                m.Prenume = id.ItemArray[2].ToString();
                m.tip_camera = (Tip_camera)Enum.Parse(typeof(Tip_camera),id.ItemArray[3].ToString());
                m.check_in = DateTime.Parse(id.ItemArray[4].ToString());
                m.check_out = DateTime.Parse(id.ItemArray[5].ToString());
                m.carte_de_credit= (Carte_de_credit)Enum.Parse(typeof(Carte_de_credit), id.ItemArray[6].ToString());
                m.numar_carte= id.ItemArray[7].ToString();
                m.Data_expirarii= id.ItemArray[8].ToString();
                m.CCV= id.ItemArray[9].ToString();
                m.Mentiuni= id.ItemArray[10].ToString();
                lista_clienti.Add(m);
            }
        }
    }
}
