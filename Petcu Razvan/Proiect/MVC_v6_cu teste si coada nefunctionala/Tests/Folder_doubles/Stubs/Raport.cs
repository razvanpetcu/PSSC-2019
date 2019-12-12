using MVC_CORE.Models;
using MVC_CORE_TEST.Folder_doubles.Dummy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Stubs
{
    public class Raport
    {
        public Raport() { }
        public void Report(IAudit a,IIncasari i, Prognoza_pe_baza_de_statisticics p,Puncte_de_vanzare v,Model_clienti m,float pret,string camera)
        {
            bool ok = a.Completare_raport(m, p, v);
            float res = i.Calcul_pret(pret, camera, v);
        }
    }
}
