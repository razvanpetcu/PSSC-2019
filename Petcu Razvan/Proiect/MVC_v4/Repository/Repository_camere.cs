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
    public class Repository_camere
    {
        private static string ConnectionString = "server = localhost; port = 3306; database = test; user = root; password = root";
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public static bool Update_camera(Tip_camera t)
        {
            if (Verificare.Verificare_camera(t) != null)
            {

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query,id;
                    id = Cautare_camera_pe_tip(t);
                    if (id == null)
                        return false;
                    query = "UPDATE camere SET "+t.ToString()+"='rezervat' WHERE ID='"+id+"';";                                                             
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader myreader;

                    myreader = cmd.ExecuteReader();//EXECUTE QUERY

                    return true;
                }
            }else
                return false;
        }
        private static string Cautare_camera_pe_tip(Tip_camera t)
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
                if (stare_camere.ItemArray[0].ToString() == "liber curata")
                {
                    return stare_camere.ItemArray[1].ToString();
                }
            }
            return null;
        }
    }
}
