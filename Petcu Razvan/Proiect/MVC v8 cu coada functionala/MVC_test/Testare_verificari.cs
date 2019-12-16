using ClassLibrary1;
using MVC_CORE.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary1.Model_clienti;

namespace MVC_CORE_TEST
{
    class Testare_verificari
    {
        Model_clienti model_client = new Model_clienti();
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
        //testare nume la fel cu prenume
        [Test]
        [TestCase("153613")]
        [TestCase("numeds")]
        [TestCase("dsa#$$#@^")]
        [TestCase("nume")]
        public void Test_nume_good(string nume)
        {
            //Arrange
            bool result = true;
            //Act
            result = Verificare.Verificare_nume(nume);
            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("12")]
        public void Test_nume_fail(string nume)
        {
            //Arrange
            bool result = true;
            //Act
            result = Verificare.Verificare_nume(nume);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_verificare_camera_good()
        {
            //Arrange
            bool result = true;
            //Act
            result = Verificare.Verificare_camera(Model_clienti.Tip_camera.Lux);
            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void Test_verificare_camera_fail()
        {
            //Arrange
            bool result = true;
            //Act
            result = Verificare.Verificare_camera(Model_clienti.Tip_camera.Standard);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_verificare_tip_camera_good()
        {
            //Arrange
            Model_clienti m1 = new Model_clienti();
            m1.ID = "1";
            bool result = false;
            //Act
            result = Verificare.Verificare_tip_camera_modificat(m1);
            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void Test_verificare_tip_camera_fail()
        {
            //Arrange
            Model_clienti m1 = new Model_clienti();
            m1.ID = "3";
            bool result = false;
            //Act
            result = Verificare.Verificare_tip_camera_modificat(m1);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_verificare_camera_disponibila_good()
        {
            //Arrange
            bool result = false;
            //Act
            result = Verificare.Verificare_camera(model_client.tip_camera,model_client.check_in,model_client.check_out);
            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void Test_verificare_camera_disponibila_fail()
        {
            //Arrange
            bool result = false;
            //Act
            result = Verificare.Verificare_camera(Model_clienti.Tip_camera.Standard, model_client.check_in, model_client.check_out);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase("08/12/2020", "15/12/2020")]
        [TestCase("28/12/2019", "29/12/2019")]
        public void Test_verificare_date_valabile_good(string check_in,string check_out)
        {
            //Arrange
            DateTime check_ind = DateTime.Parse(check_in);
            DateTime check_outd = DateTime.Parse(check_out);
            Tip_camera t1 = Tip_camera.Standard;
            Tip_camera t2= Tip_camera.Lux;
            Tip_camera t3= Tip_camera.Superior;
            bool result1, result2, result3;
            //Act
            result1 = Verificare.Verificare_date_valabile(check_ind, check_outd,t1);
            result2 = Verificare.Verificare_date_valabile(check_ind, check_outd, t2);
            result3 = Verificare.Verificare_date_valabile(check_ind, check_outd, t3);
            //Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }
        [Test]
        [TestCase("08/12/2019", "15/12/2019")]
        [TestCase("10/12/2019", "11/12/2019")]
        [TestCase("15/12/2019", "17/12/2019")]
        [TestCase("27/12/2019", "29/12/2019")]
        public void Test_verificare_date_valabile_fail(string check_in, string check_out)
        {
            //Arrange
            DateTime check_ind = DateTime.Parse(check_in);
            DateTime check_outd = DateTime.Parse(check_out);
            Tip_camera t2 = Tip_camera.Lux;
            Tip_camera t3 = Tip_camera.Superior;
            bool result2, result3;
            //Act
            result2 = Verificare.Verificare_date_valabile(check_ind, check_outd, t2);
            result3 = Verificare.Verificare_date_valabile(check_ind, check_outd, t3);
            //Assert
            if (result2 == true || result3 == true)
            {
                Assert.Pass();
            } else
                Assert.Fail();
        }
    }
}
