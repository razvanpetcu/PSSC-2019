using MVC_CORE_TEST.Folder_doubles.spy_mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST.Folder_doubles.Dummy
{
    public class Initiere_cont
    {
        public readonly Moq.Mock m;
        public Initiere_cont() { }
        public Initiere_cont(Moq.Mock m) { }
        public Initiere_cont(Moq.Mock<ILog> m) { }
    }
}
