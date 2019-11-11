using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Formular
    {
        public string tip_camere { get; set; }
        public string data_check_in { get; set; }
        public string data_check_out { get; set; }
        public string nume_prenume { get; set; }
        public string numar_persoane { get; set; }
        public string email { get; set; }
        public string mod_plata { get; set; }
        public string mentiuni { get; set; }


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