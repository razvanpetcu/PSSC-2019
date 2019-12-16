using MVC_CORE_TEST.Folder_doubles.spy_mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Dummy
{
    public class Puncte_de_vanzare
    {
        public readonly Moq.Mock m;
        public Puncte_de_vanzare() { }
        public Puncte_de_vanzare(Initiere_cont i, Moq.Mock m) { }
        public Puncte_de_vanzare(Initiere_cont i, Moq.Mock<ILog> m) { }
    }
}
