using ClassLibrary1;
using MVC_CORE.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static ClassLibrary1.Model_clienti;
using static MVC_CORE.Models.Camere;

namespace MVC_CORE.Repository
{
    public class Repository_camere
    {
        private static string ConnectionString = "server = localhost; port = 3306; database = test; user = root; password = root";
        public static List<Camere> lista_camere = new List<Camere>();
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public static bool Update_camera(Model_clienti m)
        {
            if (!Verificare.Verificare_camera(m.tip_camera))
            {

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query,id;
                    id = Cautare_camera_pe_tip(m.tip_camera);
                    if (id == null)
                        return false;
                    query = "UPDATE camere SET "+m.tip_camera.ToString()+"='rezervat' WHERE ID='"+id+"';";                                                             
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY
                    m.id_camera = id;
                    return true;
                }
            }else
                return false;
        }
        public static string Cautare_camera_pe_tip(Tip_camera t)
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
                if (stare_camere.ItemArray[0].ToString() == "liber_curata")
                {
                    return stare_camere.ItemArray[1].ToString();
                }
            }
            return null;
        }
        public static void Actualizare_lista_camere()
        {
            lista_camere.Clear();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "select * from Camere;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_camere_db = dTable.AsEnumerable().ToList();
            foreach (DataRow stare_camere in list_camere_db)
            {
                Camere c = new Camere();
                c.id = stare_camere.ItemArray[0].ToString();
                c.lux = (Lux)Enum.Parse(typeof(Lux), stare_camere.ItemArray[1].ToString());
                c.sup = (Superior)Enum.Parse(typeof(Superior), stare_camere.ItemArray[2].ToString());
                c.std = (Standard)Enum.Parse(typeof(Standard), stare_camere.ItemArray[3].ToString());
                c.numar_camere= stare_camere.ItemArray[4].ToString();
                lista_camere.Add(c);
            }
        }
        public static void Actualizare_camere_db(List<Camere> lista_camere_db)
        {
            foreach (Camere c in lista_camere_db) {

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query;
                    query = "UPDATE Camere SET Lux='" + c.lux.ToString() + "',Superior='" + c.sup.ToString() + "',Standard='" + c.std.ToString() + "' WHERE ID='" + c.id + "';";
    
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY
                }
            }
        }
        public static void Adaugare_camera()
        {
            Camere c = new Camere();
            c.id = id_camere();
            c.lux = Lux.liber_curata;
            c.sup = Superior.liber_curata;
            c.std = Standard.liber_curata;
            c.numar_camere = numar_camer();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;
                query = "INSERT INTO Camere VALUES('"+c.id+"','"+c.lux.ToString()+"','"+c.sup.ToString()+"','"+c.std.ToString()+"','" +c.numar_camere+ "');";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
            }
        }
        public static string numar_camer()
        {
            string numar_camera = null;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;
                //QUERY
                query = "SELECT Numar_camere FROM Camere;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                adapt.Fill(dTable);
                List<DataRow> list_camere = dTable.AsEnumerable().ToList();
                foreach (DataRow numar_camere_db in list_camere)
                {
                    numar_camera = numar_camere_db.ItemArray[0].ToString();
                }
                numar_camera = (int.Parse(numar_camera.Substring(0, 1)) + 3).ToString()+","+ (int.Parse(numar_camera.Substring(2, 1)) + 3).ToString() + "," + (int.Parse(numar_camera.Substring(4, 1)) + 3).ToString();
            }
            return numar_camera;
        }
        public static string id_camere()
        {
            int id = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;
                //QUERY
                query = "SELECT ID FROM Camere;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;
                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                adapt.Fill(dTable);
                List<DataRow> list_camere = dTable.AsEnumerable().ToList();
                foreach (DataRow id_Camere_db in list_camere)
                {
                    id = int.Parse(id_Camere_db.ItemArray[0].ToString());
                }
                id++;
            }
            return id.ToString();
        }
        public static void SUPER_actualizare_camere()
        {
            Curata_camere();
            Repository_clienti.Actualizare_lista();
            foreach (Model_clienti m in Repository_clienti.lista_clienti)
            {
                if (m.stare != Stare.Inactiv)
                {
                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();
                        string query, id;
                        id = Cautare_camera_pe_tip(m.tip_camera);
                        query = "UPDATE camere SET " + m.tip_camera.ToString() + "='rezervat' WHERE ID='" + id + "';";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader myreader;

                        myreader = cmd.ExecuteReader();//EXECUTE QUERY
                        m.id_camera = id;
                    }
                }
            }
        }
        public static void Eliberare_o_camera(Tip_camera tip_pentru_deactualizare)
        {
            Actualizare_lista_camere();
            foreach (Camere c in lista_camere)
            {
                if (tip_pentru_deactualizare.ToString() == "Lux" && c.lux==Lux.rezervat)
                {
                    Eliberare_camera(c.id,"Lux");
                    break;
                }
                if (tip_pentru_deactualizare.ToString() == "Superior" && c.sup == Superior.rezervat)
                {
                    Eliberare_camera(c.id, "Superior");
                    break;
                }
                if (tip_pentru_deactualizare.ToString() == "Standard" && c.std == Standard.rezervat)
                {
                    Eliberare_camera(c.id, "Standard");
                    break;
                }
            }
        }
        public static void Eliberare_camera(string id,string tip_camera)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;
                query = "UPDATE camere SET " + tip_camera + "='liber_curata' WHERE ID='" + id + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
            }
        }
        public static void Curata_camere()
        {
            string query;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                query = "UPDATE camere SET Lux='liber_curata'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader;

                myreader = cmd.ExecuteReader();//EXECUTE QUERY
            }
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                query = "UPDATE camere SET Superior='liber_curata'";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                MySqlDataReader myreader1;

                myreader1 = cmd1.ExecuteReader();//EXECUTE QUERY
            }
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                query = "UPDATE camere SET Standard='liber_curata'";
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataReader myreader2;

                myreader2 = cmd2.ExecuteReader();//EXECUTE QUERY
            }
        }
    }
}
