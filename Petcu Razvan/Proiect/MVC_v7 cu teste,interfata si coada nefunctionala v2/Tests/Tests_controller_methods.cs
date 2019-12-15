using Microsoft.AspNetCore.Mvc;
using MVC_CORE.Controllers;
using MVC_CORE.Models;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace MVC_CORE_TEST
{
    public class Tests_controller_methods
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
        public void Test_Rezervare_GET()
        {
            //Arrange
            var controller = new HomeController();
            //Act
            var result = controller.Rezervare();
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_Rezervare_POST_not_insert()
        {
            //Arrange
            var controller = new HomeController();
            var model_client = new Model_clienti();
            //Act
            var result = controller.Rezervare(model_client);
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_Rezervare_POST_Insert()
        {
            //Arrange
            var controller = new HomeController();
            Setup();
            //Act
            var result = controller.Rezervare(model_client);
            //Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            Assert.IsNull(model_client.fail);
        }
        [Test]
        public void Test_Confirmare_GET()
        {
            //Arrange
            var controller = new HomeController();
            Setup();
            //Act
            var rezervare = controller.Rezervare(model_client);
            var result = controller.Confirmare();
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.NotNull(HomeController.c1);
            Assert.NotNull(HomeController.id);
            Assert.NotNull(HomeController.model);
        }
        [Test]
        public void Test_confirmare_POST()
        {
            //Arrange
            var controller = new HomeController();
            var c1 = new Confirmare();
            //Act
            var result = controller.Confirmare(c1);
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_actualizare_client_GET()
        {
            var controller = new HomeController();
            var model_client = new Model_clienti();
            //Act
            var result = controller.Actualizare_client(model_client);
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_actualizare_client_POST()
        {
            var controller = new HomeController();
            var model_client = new Model_clienti();
            //Act
            var result = controller.Actualizare_client(model_client," ");
            //Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void Test_COD_GET()
        {
            //Arrange
            var controller = new HomeController();
            //Act
            var result = controller.COD();
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_COD_POST_good()
        {
            //Arrange
            var controller = new HomeController();
            var cod = new COD();
            cod.id = "1";
            //Act
            var insert = controller.Rezervare(model_client);
            var result = controller.COD(cod);
            //Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void Test_COD_POST_fail_id()
        {
            //Arrange
            var controller = new HomeController();
            var cod = new COD();
            cod.id = "1";
            cod.fail = "ceva";
            //Act
            var result = controller.COD(cod);
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_Anulare_GET()
        {
            //Arrange
            var controller = new HomeController();
            HomeController.id = "1";
            //Act
            var insert = controller.Rezervare(model_client);
            var result = controller.Anulare();
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void Test_pagina_modificare_GET()
        {
            //Arrange
            var controller = new HomeController();
            //Act
            var result = controller.Modificare();
            //Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}