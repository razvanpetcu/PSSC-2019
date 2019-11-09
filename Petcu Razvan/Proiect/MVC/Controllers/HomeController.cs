using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;


namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //GET
        public ActionResult Index()
        {
            string titlu = " Bun venit :Nume Hotel";
            string Adresa = "strada .... nr .... ";
            string numar_telefon = "05156522";
            string email = "mail@yahoo.com";
            string servicii = "serviciul 1 serviciul 2 serviciul 3";
            string oferte = "oferta 1 oferta 2";
            Home h = new Home(titlu, Adresa, numar_telefon, email, servicii, oferte);
            return View(h);
        }
        //GET
        public ActionResult Rezervare()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Rezervare(Formular f)
        {
            Debug.WriteLine(f.tip_camere+" ceva");
            return View(f);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}