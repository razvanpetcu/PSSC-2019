using ClassLibrary1;
using MassTransit;
using MVC_CORE.Controllers;
using MVC_CORE.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_CORE_TEST
{
    class Test_Models
    {
        Model_clienti model_client = new Model_clienti();
        MVC_CORE.Service servicu;
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
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("amqp://xjkfljkg:6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs@hawk.rmq.cloudamqp.com/xjkfljkg"), h =>
                {
                    h.Username("xjkfljkg");
                    h.Password("6f3VVB4u_9BuC-iPf0-FKzRnwET1GHNs");
                });
            });

            bus.Start();

            servicu = new MVC_CORE.Service(bus);
        }
        [Test]
        [TestCase("0")]
        [TestCase("5")]
        [TestCase("11233456805")]
        [TestCase("01")]
        public void Test_COD_verificare_string_good(string id)
        {
            //Arrange
            var cod = new COD();
            cod.id = id;
            bool v = false;
            //Act
            v=cod.Valid_string();
            //Assert
            Assert.IsTrue(v);
        }
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("156dsa")]
        [TestCase("!@##@$$#%^&&^*(")]
        [TestCase(" 123 ")]
        public void Test_COD_verificare_string_fail(string id)
        {
            //Arrange
            var cod = new COD();
            cod.id = id;
            bool v = true;
            //Act
            v = cod.Valid_string();
            //Assert
            Assert.IsFalse(v);
        }
        [Test]
        [TestCase("1")]
        public void Test_COD_validare_ID_good(string id)
        {
            //Arrange
            var controller = new HomeController(servicu);
            var cod = new COD();
            cod.id = id;
            bool v;
            //Act
            var insert = controller.Rezervare(model_client);
            v = cod.Valid_id();
            //Assert
            Assert.IsTrue(v);
        }
        [Test]
        [TestCase("2")]
        public void Test_COD_validare_ID_fail(string id)
        {
            //Arrange
            var cod = new COD();
            cod.id = id;
            bool v;
            //Act
            v = cod.Valid_id();
            //Assert
            Assert.IsFalse(v);
        }
    }
}
