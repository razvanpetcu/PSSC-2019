using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Repository
{
    public class Repository_camere
    {
        private static Baza_de_dateEntities1 _db = new Baza_de_dateEntities1();
        public static List<Camere> lista_camere = new List<Camere>();

        public static void Getall()
        {
            lista_camere = _db.Cameres.ToList();
        }
    }
}