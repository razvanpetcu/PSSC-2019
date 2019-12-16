using MVC_CORE_TEST.Folder_doubles.spy_mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Dummy
{
    public class Prognoza_pe_baza_de_statisticics
    {
        public readonly Moq.Mock m;
        public Prognoza_pe_baza_de_statisticics() { }
        public Prognoza_pe_baza_de_statisticics(List<Initiere_cont> lista, Moq.Mock m) { }
        public Prognoza_pe_baza_de_statisticics(List<Initiere_cont> lista, Moq.Mock<ILog> m) { }
    }
}
