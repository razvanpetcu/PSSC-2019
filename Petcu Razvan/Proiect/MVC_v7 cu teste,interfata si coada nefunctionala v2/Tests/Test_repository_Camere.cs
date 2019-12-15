using MVC_CORE.Models;
using MVC_CORE.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static MVC_CORE.Models.Model_clienti;

namespace MVC_CORE_TEST
{
    class Test_repository_Camere
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
        public void Testare_update_camera_good()
        {
            //Arrange
            bool result = false;
            //Act
             result = Repository_camere.Update_camera(model_client);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        [TestCase(Tip_camera.Lux)]
        [TestCase(Tip_camera.Standard)]
        [TestCase(Tip_camera.Superior)]
        public void Testare_cautare_camera_good(Tip_camera t)
        {
            //Arrange
            string result = null;
            //Act
            result = Repository_camere.Cautare_camera_pe_tip(t);
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]//se pun camerele toate rezervate in DB
        [TestCase(Tip_camera.Lux)]
        [TestCase(Tip_camera.Standard)]
        [TestCase(Tip_camera.Superior)]
        public void Testare_cautare_camera_fail(Tip_camera t)
        {
            //Arrange
            string result = null;
            //Act
            result = Repository_camere.Cautare_camera_pe_tip(t);
            //Assert
            Assert.IsNull(result);
        }
        [Test]
        public void Testare_actualizare_lista_camere()
        {
            //Arrange

            //Act
            Repository_camere.Actualizare_lista_camere();
            //
            Assert.IsNotNull(Repository_camere.lista_camere);
        }
        [Test]
        public void Testare_actulizare_DB_din_lista()
        {
            //Arrange
            List<Camere> list = new List<Camere>();
            Camere c = new Camere();
            c.id = "1";
            c.lux = Camere.Lux.rezervat;
            c.sup = Camere.Superior.rezervat;
            c.std = Camere.Standard.rezervat;
            list.Add(c);
            //Act
            Repository_camere.Actualizare_camere_db(list);
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Testare_adauga_camere()
        {
            //Arrange

            //Act
            Repository_camere.Adaugare_camera();
            //Assert
            Assert.Pass();
        }
        [Test]
        public void Test_numere_camere()
        {
            //Arrange
            string result = null;
            //Act
            result = Repository_camere.numar_camer();
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Test_id_camere()
        {
            //Arrange
            string result = null;
            //Act
            result = Repository_camere.id_camere();
            //Assert
            Assert.IsNotNull(result);
        }
    }

}
