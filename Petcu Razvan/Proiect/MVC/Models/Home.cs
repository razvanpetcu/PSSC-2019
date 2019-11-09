using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Home
    {
        public string titlu { get; set; }
        public string Adresa{ get; set; }
        public string nr_telefon { get; set; }
        public string email { get; set; }
        public string servicii { get; set; }
        public string oferte { get; set; }
        public Home(string t,string A,string n,string e,string s,string o)
        {
            this.titlu = t;
            this.Adresa = A;
            this.nr_telefon = n;
            this.email = e;
            this.servicii = s;
            this.oferte = o;
        }
    }
}