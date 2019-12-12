using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class Camere
    {
        public string id { get; set; }
        public Lux lux { get; set; }
        public Superior sup { get; set;}
        public Standard std { get; set; }
        public string numar_camere { get; set; }
        public Camere() { }
        public enum Lux{
            [Display(Name ="liber_curata")]
            liber_curata,
            [Display(Name = "liber_in_curatenie")]
            liber_in_curatenie,
            [Display(Name = "rezervat")]
            rezervat,
            [Display(Name = "ocupata")]
            ocupata,
            [Display(Name = "in_serviciu")]
            in_serviciu
        }
        public enum Superior
        {
            [Display(Name = "liber_curata")]
            liber_curata,
            [Display(Name = "liber_in_curatenie")]
            liber_in_curatenie,
            [Display(Name = "rezervat")]
            rezervat,
            [Display(Name = "ocupata")]
            ocupata,
            [Display(Name = "in_serviciu")]
            in_serviciu
        }
        public enum Standard
        {
            [Display(Name = "liber_curata")]
            liber_curata,
            [Display(Name = "liber_in_curatenie")]
            libera_in_curatenie,
            [Display(Name = "rezervat")]
            rezervat,
            [Display(Name = "ocupata")]
            ocupata,
            [Display(Name = "in_serviciu")]
            in_serviciu
        }
    }
}
