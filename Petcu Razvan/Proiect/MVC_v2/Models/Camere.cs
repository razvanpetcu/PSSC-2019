//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Camere
    {

        public string ID { get; set; }
        public string Lux { get; set; }
        public string Superior { get; set; }
        public string Standard { get; set; }
        public string Numere_camere { get; set; }
        public Camere() { }
        public Camere(string iD, string lux, string superior, string standard, string numere_camere)
        {
            ID = iD;
            Lux = lux;
            Superior = superior;
            Standard = standard;
            Numere_camere = numere_camere;
        }
    }
}
