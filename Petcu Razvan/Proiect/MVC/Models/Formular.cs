using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Formular
    {
        public string tip_camere;
        public string data_check_in;
        public string data_check_out;
        public string nume_prenume;
        public string numar_persoane;
        public string email;
        public string mod_plata;
        public string mentiuni;


        public enum Tip_camere
        {
            Superior,
            De_lux,
            Mini_suite
        }
        public enum Mod_Plata
        {
            Cash,
            Credit_Debit_Card
        }
    }
}