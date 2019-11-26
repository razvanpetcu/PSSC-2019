using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_CORE.Models;
using MVC_CORE.Repository;

namespace MVC_CORE.Controllers
{
    public class HomeController : Controller
    {
        private int id;
        private bool ok = false;
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
        //GET
        public ActionResult Rezervare()
        {

            return View();
        }

        //POST
        [HttpPost]//De aici la view-ul administratorului
        public ActionResult Rezervare(Model_clienti m)
        {
            Repository_clienti.Insert(m);
            return View(m);
        }
        [HttpPost]
        public ActionResult Actualizare_client(Model_clienti m_nou)
        {
            if (ok)
            {
                //Repository_clienti.Update(m);
            }
            ok = true;
            return View(m_nou);
        }
        [HttpPost]
        public ActionResult COD(COD c)
        {
            ok = false;
            Model_clienti model;
            id = c.id;
            model = Repository_clienti.Cautare_client(id);
            return RedirectToAction("Actualizare_client", model);
        }

        public ActionResult View_shared()
        {

            return View();
        }
    }
}
