using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class Model_clienti
    {
        public int ID { get; set; }
        // proprietati mesaje(data annotation),remotre action controller si parametri de intrare
        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Display(Name = "Tip camera")]
        public Tip_camera tip_camera { get; set; }

        [Display(Name = "check in")]
        [DataType(DataType.Date)]
        public DateTime check_in { get; set; }

        [Display(Name = "check out")]
        [DataType(DataType.Date)]
        public DateTime check_out { get; set; }

        [Display(Name = "tip carte credit")]
        public Carte_de_credit carte_de_credit { get; set; }

        [Required]
        [Display(Name = "Data expirarii")]
        public string Data_expirarii { get; set; }

        [Required]
        [Display(Name = "Numar carte")]
        public string numar_carte { get; set; }

        [Required]
        [Display(Name = "CCV")]
        public string CCV { get; set; }

        [Display(Name = "Mentiuni")]
        public string Mentiuni { get; set; }

        [Required]
        [Display(Name = "email")]
        public string email { get; set; }

        public string fail { get; set; }

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
            Rezervat
        }
    }
}
