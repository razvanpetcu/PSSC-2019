using MVC_CORE.Models;
using MVC_CORE_TEST.Folder_doubles.Dummy;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MVC_CORE_TEST.Folder_doubles.spy_mock;
using MVC_CORE_TEST.Folder_doubles.Stubs;

namespace MVC_CORE_TEST
{
    class Test_doubles
    {
        Model_clienti model_client = new Model_clienti();
        Prognoza_pe_baza_de_statisticics p = new Prognoza_pe_baza_de_statisticics();
        Puncte_de_vanzare v = new Puncte_de_vanzare();
        [SetUp]
        public void Setup()
        {
            model_client.Nume = "Nume1";
            model_client.Prenume = "Prenume1";
            model_client.tip_camera = Model_clienti.Tip_camera.Lux;
            model_client.check_in = DateTime.Now;
            model_client.check_out = DateTime.Now;
            model_client.carte_de_credit = Model_clienti.Carte_de_credit.Master_Card;
            model_client.numar_carte = "1234567891234567";
            model_client.Data_expirarii = "05/21";
            model_client.CCV = "213";
            model_client.Mentiuni = "ceva";
        }
        [Test]
        public void Test_module_externe1()
        {
            //Arrange
            var logMock1 = new Moq.Mock<ILog>();
            var logMock2 = new Moq.Mock<ILog>();
            var logMock3 = new Moq.Mock<ILog>();
            var cont = new Initiere_cont(logMock1);
            List<Initiere_cont> lista = new List<Initiere_cont>();
            var prognoza = new Prognoza_pe_baza_de_statisticics(lista, logMock2);
            var vanzare = new Puncte_de_vanzare(cont, logMock3);

            //Act
            logMock1.Setup(d => d.Log("method Log was called with message :Initiere_cont"));
            logMock2.Setup(d => d.Log("method Log was called with message :Prognoza_pe_baza_de_statisticics"));
            logMock3.Setup(d => d.Log("method Log was called with message :Puncte_de_vanzare"));
            //Assert
            logMock1.Verify();
            logMock2.Verify();
            logMock3.Verify();
        }
        [Test]
        public void Test_module_externe2()
        {
            //Arrange
            var mock_audit = new Mock<IAudit>();
            var Audit = new Audit_noapte();
            var mock_incasari = new Mock<IIncasari>();
            var incasari = new Incasari();
            var rap = new Raport();

            bool ok = false;
            float res = 0;

            mock_audit.Setup(_ => _.Completare_raport(model_client, p, v)).Returns(true);
            mock_incasari.Setup(_ => _.Calcul_pret(15, "Lux",v)).Returns(15*15);

            //Act
            ok = Audit.Completare_raport(model_client, p, v);
            res = incasari.Calcul_pret(15, "Lux", v);
            rap.Report(mock_audit.Object, mock_incasari.Object, p, v, model_client, 15, "Lux");

            //Assert
            mock_audit.Verify(_ => _.Completare_raport(model_client, p, v), Times.Once());
            mock_incasari.Verify(_ => _.Calcul_pret(15, "Lux", v), Times.Once());
        }
    }
}
