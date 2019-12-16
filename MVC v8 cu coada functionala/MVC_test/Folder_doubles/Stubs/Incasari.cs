using MVC_CORE_TEST.Folder_doubles.Dummy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Stubs
{
    class Incasari:IIncasari
    {
        public Incasari() { }
        public float Calcul_pret(float pret,string camera,Puncte_de_vanzare p) 
        {
            float val=0;
            if (camera == "Lux")
                val = 15;
            if (camera == "Superior")
                val = 10;
            if (camera == "Standard")
                val = 5;
            return pret*val;
        }
    }
}
