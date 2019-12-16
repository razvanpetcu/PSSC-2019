using ClassLibrary1;
using MVC_CORE.Models;
using MVC_CORE_TEST.Folder_doubles.Dummy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Stubs
{
    public interface IAudit
    {
        public bool Completare_raport(Model_clienti m, Prognoza_pe_baza_de_statisticics p,Puncte_de_vanzare v);
    }
}
