using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_CORE.Models;
using MVC_CORE.Repository;

namespace MVC_CORE.Controllers
{
    public class AdminController : Controller
    {
        //GET
        public ActionResult Admin_clienti()
        {
             Repository_camere.Actualizare_lista_camere();
             return View(Repository_camere.lista_camere);
        }

        [HttpPost]
        public ActionResult Admin_clienti(List<Camere> lista_noua_camere)
        {
            Repository_camere.Actualizare_camere_db(lista_noua_camere);
            return View(lista_noua_camere);
        }
        //GET
        public ActionResult Adaugare_camere()
        {
            Repository_camere.Adaugare_camera();
            return RedirectToAction("Admin_clienti");
        }
        //GET
        public ActionResult Rapoarte_clienti()
        {
            Repository_clienti.Actualizare_lista();
            return View(Repository_clienti.Sortare_lista());
        }
    }
}