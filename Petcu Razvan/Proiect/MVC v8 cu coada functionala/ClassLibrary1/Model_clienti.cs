using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    public class Model_clienti
    {
        [Display(Name ="ID")]
        public string ID { get; set; }
        [Display(Name = "Nume")]
        public string Nume { get; set; }
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }
        [Display(Name = "Tip Camera")]
        public Tip_camera tip_camera { get; set; }
        [Display(Name = "Check In")]
        public DateTime check_in { get; set; }
        [Display(Name = "Check Out")]
        public DateTime check_out { get; set; }
        [Display(Name = "Tip de carte de credit")]
        public Carte_de_credit carte_de_credit { get; set; }
        [Display(Name = "Data de expirare")]
        public string Data_expirarii { get; set; }
        [Display(Name = "Numar carte")]
        public string numar_carte { get; set; }
        [Display(Name = "CCV")]
        public string CCV { get; set; }
        [Display(Name = "Mentiuni")]
        public string Mentiuni { get; set; }
        public string email { get; set; }

        public string fail { get; set; }

        public Stare stare { get; set; }

        public string id_camera { get; set; }

        public enum Tip_camera
        {
            [Display(Name = "Lux")]
            Lux,
            [Display(Name = "Superior")]
            Superior,
            [Display(Name = "Standard")]
            Standard
        }
        public enum Carte_de_credit
        {
            [Display(Name = "Master card")]
            Master_Card,
            [Display(Name = "Visa")]
            Visa
        }
        public enum Stare
        {
            Activ,
            Inactiv
        }
        public Model_clienti() { }
    }
}
