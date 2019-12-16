using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_CORE.Models;
using MVC_CORE.Repository;

namespace MVC_CORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService serviciu;
        public static string id;//memorare id de confirmare/modificare
        public static Model_clienti model = new Model_clienti();//returnare parametri conform codului
        public static Confirmare c1 = new Confirmare();//model de confirmare dupa rezervare
        public static Model_clienti coada = new Model_clienti();
        public HomeController(IService service)
        {
            this.serviciu = service;
        }
        public void Send(ClassLibrary1.Model_clienti m)
        {
            serviciu.Add_client(m);
        }
        public ActionResult Home()
        {
            string titlu = " Bun venit :Nume Hotel";
            string Adresa = "strada .... nr .... ";
            string numar_telefon = "05156522";
            string email = "mail@yahoo.com";
            string servicii = "serviciul 1 serviciul 2 serviciul 3";
            string oferte = "oferta 1 oferta 2";
            Home h = new Home(titlu, Adresa, numar_telefon, email, servicii, oferte);
            return View();
        }

        #region Rezervare
        //GET
        public ActionResult Rezervare()
        {
            Model_clienti m = new Model_clienti();
            m.fail = null;
            return View(m);
        }
        //POST
        [HttpPost]//De aici la view-ul administratorului
        public ActionResult Rezervare(Model_clienti m)
        {
            serviciu.Add_client(m);
            Receive.Program.Main();          
            if (Repository_clienti.Insert(m))
            {
                c1.id_confirmare = m.ID;
                c1.m = m;
                id = c1.id_confirmare;
                return RedirectToAction("Confirmare");
            }
            return View(m);
        }
        #endregion

        #region Confirmare
        public ActionResult Confirmare()
        {
            return View(c1);
        }
        [HttpPost]
        public ActionResult Confirmare(Confirmare c)
        {
            return View(c);
        }
        #endregion

        #region modificari client
        [HttpGet]
        public ActionResult Actualizare_client(Model_clienti m)
        {
            model = m;
            m.fail = null;
            return View(m);
        }
        [HttpPost]
        public ActionResult Actualizare_client(Model_clienti m, string s)
        {
            Repository_clienti.Update(m, id,model.tip_camera);
            return RedirectToAction("Modificare");
        }
        #endregion

        #region Pagina introducere COD
        public ActionResult COD()
        {
            COD c = new COD();
            c.fail = null;
            return View(c);
        }
        [HttpPost]
        public ActionResult COD(COD c)
        {
            c.Verificare();
            if (c.fail != null)
            {
                return View(c);
            }
            Model_clienti model1;
            id = c.id;
            model1 = Repository_clienti.Cautare_client(id);
            return RedirectToAction("Actualizare_client", model1);
        }
        #endregion

        #region Pagina dupa buton anulare
        [HttpPost]
        public ActionResult Anulare()
        {
            Repository_clienti.Anulare_rezervare(id);
            return View();
        }
        #endregion

        #region Pagina dupa butonul de modificare
        [HttpGet]
        public ActionResult Modificare()
        {
            return View();
        }
        #endregion
    }
}
