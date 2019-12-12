using MVC_CORE.Models;
using MVC_CORE.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static MVC_CORE.Models.Model_clienti;

namespace MVC_CORE_TEST
{
    class Testare_repository_clienti
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
        [Test]
        public void Test_insert_first_good()
        {
            //Arrange
            bool result = false;
            //Act
            result = Repository_clienti.First(model_client);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_insert_first_fail()
        {
            //Arrange
            bool result = false;
            //Act
            result = Repository_clienti.First(model_client);
            //Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void Test_insert()
        {
            //Arrange
            bool result = false;
            //Act
            result = Repository_clienti.Insert(model_client);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test_Update()
        {
            //Arrange
            model_client.ID = "2";
            model_client.Nume = "Nume2";
            model_client.tip_camera = Model_clienti.Tip_camera.Superior;
            //Act
            string result = Repository_clienti.Update(model_client,"1",Model_clienti.Tip_camera.Lux);
            //Assert
            Assert.IsNull(result);
        }
        [Test]
        public void Test_verif_rep()
        {
            //Arrange

            //Act
            Repository_clienti.Verif(model_client);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_verif_update_rep()
        {
            //Arrange

            //Act
            Repository_clienti.Verif_up(model_client);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_maxim()
        {
            //Arrange
            int max = 0;
            //Act
            max = Repository_clienti.maxim();
            //Assert
            Assert.AreEqual(2, max);
        }
        [Test]
        [TestCase("1")]
        public void Test_cautare_client_good(string id)
        {
            //Arrange
            Model_clienti m1 = new Model_clienti();
            //Act
            m1 = Repository_clienti.Cautare_client(id);
            //Assert
            Assert.AreEqual(m1.Nume, model_client.Nume);
            Assert.AreEqual(m1.Prenume, model_client.Prenume);
            Assert.AreEqual(m1.tip_camera, model_client.tip_camera);
            Assert.AreEqual(m1.carte_de_credit, model_client.carte_de_credit);
            Assert.AreEqual(m1.CCV, model_client.CCV);
            Assert.AreEqual(m1.Data_expirarii, model_client.Data_expirarii);
            Assert.AreEqual(m1.Mentiuni, model_client.Mentiuni);
        }
        [Test]
        [TestCase("3")]
        public void Testare_cautare_client_fail(string id)
        {
            //Arrange
            Model_clienti m1 = new Model_clienti();
            //Act
            m1 = Repository_clienti.Cautare_client(id);
            //Assert
            Assert.IsNull(m1);
        }
        [Test]
        public void Testare_actualizare_lista()
        {
            //Arrange

            //Act
            Repository_clienti.Actualizare_lista();
            //Assert
            Assert.IsNotNull(Repository_clienti.lista_clienti);
        }
        [Test]
        public void Test_deactualizare_camera_db()
        {
            //Arrange
            Model_clienti m1 = new Model_clienti();
            m1.id_camera = "2";
            m1.tip_camera = Model_clienti.Tip_camera.Lux;
            //Act
            Repository_clienti.Deactualizare_baza(m1, m1.tip_camera);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_anulare_rezervare()
        {
            //Arrange
            string id = "1";
            //Act
            Repository_clienti.Anulare_rezervare(id);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_Revenire_camera()
        {
            //Arrange
            string id_tabel_client = "2";
            //Act
            Repository_clienti.Revenire_camera(id_tabel_client);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_cautare_camera_rezervata_good()
        {
            //Arrange
            Tip_camera t = Tip_camera.Lux;
            string result = null;
            //Act
            result = Repository_clienti.Cautare_camera_rezervata(t);
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Test_cautare_camera_rezervata_fail()
        {
            //Arrange
            Tip_camera t = Tip_camera.Standard;
            string result = null;
            //Act
            result = Repository_clienti.Cautare_camera_rezervata(t);
            //Assert
            Assert.IsNull(result);
        }

    }
}
