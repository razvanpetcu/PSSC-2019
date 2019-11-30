using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class COD
    {
        private string ConnectionString = "server = localhost; port = 3306; database = test; user = root; password = root";
        [Required]
        [Display(Name ="COD")]
        public string id { get; set; }
        public string fail { get; set; }

        public string Verificare()
        {
            if (!Valid_string())
            {
                fail = "trebuie sa contina numai cifre";
            }
            else
            {
                if (!Valid_id())
                {
                    fail = "nu exista in baza de date";
                }
            }
            return fail;
        }
        private bool Valid_string()
        {
            bool isValid = true;
            foreach (char c in this.id)
            {
                if (c < '0' || c > '9')
                    isValid = false;
            }

            return isValid;
        }
        private bool Valid_id()
        {
            bool isValid = false;
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            string query = "SELECT ID FROM tabel_clienti;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            adapt.Fill(dTable);
            List<DataRow> list_id = dTable.AsEnumerable().ToList();
            foreach (DataRow id in list_id)
            {
                if (id.ItemArray[0].ToString() == this.id)
                    isValid = true;
            }
            return isValid;
        }
    }
}
