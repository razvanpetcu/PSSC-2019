using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CORE.Models
{
    public class COD
    {
        [Required]
        [Display(Name ="COD")]
        public string id { get; set; }
    }
}
