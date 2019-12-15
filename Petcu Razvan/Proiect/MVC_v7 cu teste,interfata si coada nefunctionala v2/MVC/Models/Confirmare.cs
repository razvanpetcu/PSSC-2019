using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class Confirmare
    {
        [Display(Name ="Numar confirmare")]
        public string id_confirmare { get; set; }
        public Model_clienti m { get; set; }
        public Confirmare() { }

    }
}
