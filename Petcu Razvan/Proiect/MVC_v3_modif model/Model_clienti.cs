using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Model_clienti
    {
        private Guid ID { get; set; }
        // proprietati mesaje(data annotation),remotre action controller si parametri de intrare
        [Required]
        [Display(Name = "Nume")]
        [Remote(action: "Admin_clienti", controller: "Admin", AdditionalFields = nameof(ID), ErrorMessage = "Numărul contractului există deja!")]
        public string Nume { get; set; }

        [Required]
        [Display(Name = "Prenume")]
        public string Prenume { get; set; }

        [Display(Name = "Tip camera")]
        public Tip_camera tip_Camera { get; set; }

        [Display(Name ="check in")]
        [DataType(DataType.Date)]
        public DateTime check_in { get; set; }

        [Display(Name = "check out")]
        [DataType(DataType.DateTime)]
        public DateTime check_out { get; set; }

        [Display(Name = "tip carte credit")]
        public Carte_de_credit carte_De_Credit { get; set; }

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

        public Model_clienti() { }
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