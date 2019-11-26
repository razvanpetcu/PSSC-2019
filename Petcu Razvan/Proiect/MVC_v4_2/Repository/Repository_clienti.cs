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
                            + "','" + m.numar_carte + "','" + m.Data_expirarii + "','" + m.CCV + "','" + m.Mentiuni + "','Activ');";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader myreader;
                        
                        myreader = cmd.ExecuteReader();//EXECUTE QUERY
                        Repository_camere.Update_camera(m);
                        Actualizare_lista();

                        Verificare.ok = false;
                    }
                }
            }
            return m.fail;
        }

        public static string Update(Model_clienti m,string id)
        {
            Verif_up(m);
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
                    Deactualizare_baza(m);

                    Repository_camere.Update_camera(m);
                    Actualizare_lista();
                    Revenire_camera(id);

                    Verificare.ok = false;
                }
            }
            return null;
        }

        private static void Verif(Model_clienti m)
        {
            Verificare.Verificari(m);
        }
        private static void Verif_up(Model_clienti m)
        {
            Verificare.Verificari_update(m);
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
                        + "','" + m.numar_carte + "','" + m.Data_expirarii + "','" + m.CCV + "','" + m.Mentiuni + "','Activ');";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY
                    Repository_camere.Update_camera(m);
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
        public static Model_clienti Cautare_client(string id)
        {
            Actualizare_lista();
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
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "SELECT * FROM tabel_clienti;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> lista_clienti_db = dTable.AsEnumerable().ToList();
            foreach (DataRow client in lista_clienti_db)
            {
                Model_clienti m = new Model_clienti();
                m.ID = client.ItemArray[0].ToString();
                m.Nume = client.ItemArray[1].ToString();
                m.Prenume = client.ItemArray[2].ToString();
                m.tip_camera = (Tip_camera)Enum.Parse(typeof(Tip_camera), client.ItemArray[3].ToString());
                m.check_in = DateTime.Parse(client.ItemArray[4].ToString());
                m.check_out = DateTime.Parse(client.ItemArray[5].ToString());
                m.carte_de_credit= (Carte_de_credit)Enum.Parse(typeof(Carte_de_credit), client.ItemArray[6].ToString());
                m.numar_carte= client.ItemArray[7].ToString();
                m.Data_expirarii= client.ItemArray[8].ToString();
                m.CCV= client.ItemArray[9].ToString();
                m.Mentiuni= client.ItemArray[10].ToString();
                m.stare= (Stare)Enum.Parse(typeof(Stare), client.ItemArray[11].ToString());                
                lista_clienti.Add(m);
            }
        }
        private static void Deactualizare_baza(Model_clienti m)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE camere SET " + m.tip_camera.ToString() + "='liber curata' WHERE ID='" + m.id_camera + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
            }
        }
        public static void Anulare_rezervare(string id)
        {
            using (MySqlConnection conn = GetConnection())
            { 
                conn.Open();
                string query;
                query = "UPDATE tabel_clienti SET Stare='Inactiv' WHERE ID='" + id + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
                Revenire_camera(id);
            }
        }
        private static void Revenire_camera(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string id1 = null;
                conn.Open();
                string query;
                Model_clienti m1 = new Model_clienti();
                Actualizare_lista();
                foreach (Model_clienti m in lista_clienti)
                {
                    if (m.ID == id)
                    {
                        m1 = m;
                    }
                }
                id1 = Cautare_camera_rezervata(m1.tip_camera);
                query = "UPDATE camere SET " + m1.tip_camera.ToString() + "='liber curata' WHERE ID='"+id1+"';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
            }
        }
        public static string Cautare_camera_rezervata(Tip_camera t)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "select " + t.ToString() + ",ID from Camere;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere = dTable.AsEnumerable().ToList();
            foreach (DataRow stare_camere in list_camere)
            {
                if (stare_camere.ItemArray[0].ToString() == "rezervat")
                {
                    return stare_camere.ItemArray[1].ToString();
                }
            }
            return null;
        }

    }
}
