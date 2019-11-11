using MVC.Models;
using MVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private Baza_de_dateEntities1 _db = new Baza_de_dateEntities1();
        public static Tabel_clienti t = new Tabel_clienti();
        private Guid id;
        private bool ok = true;
        // GET: Admin 2
        public void init()
        {
            Camere c1 = new Camere(Guid.NewGuid().ToString(), "liber curata", "liber curata", "liber curata", "1,2,3");
            _db.Cameres.Add(c1);
            _db.SaveChanges();

            Camere c2 = new Camere(Guid.NewGuid().ToString(), "liber curata", "liber curata", "liber curata", "4,5,6");
            _db.Cameres.Add(c2);
            _db.SaveChanges();

            Camere c3 = new Camere(Guid.NewGuid().ToString(), "liber curata", "liber curata", "liber curata", "7,8,9");
            _db.Cameres.Add(c3);
            _db.SaveChanges();
        }

        //GET
        public ActionResult Admin_date()
        {
            /*
            if (t.Tip_Camera == "Lux")
            {

                if (_db.Cameres.Where(x => x.Lux.Contains("liber curat")) != null || _db.Cameres.Where(x => x.Lux.Contains("liber in curatenie")) != null)
                {
                    _db.Tabel_clienti.Add(t);
                }
            }
            if (t.Tip_Camera == "Superior")
            {

                if (_db.Cameres.Where(x => x.Superior.Contains("liber curat")) != null || _db.Cameres.Where(x => x.Superior.Contains("liber in curatenie")) != null)
                {
                    _db.Tabel_clienti.Add(t);
                }
            }
            if (t.Tip_Camera == "Standard")
            {

                if (_db.Cameres.Where(x => x.Standard.Contains("liber curat")) != null || _db.Cameres.Where(x => x.Standard.Contains("liber in curatenie")) != null)
                {
                    _db.Tabel_clienti.Add(t);
                }
            }
            */
            return View();
        }

        //GET
        public ActionResult Admin_camere()
        {
            Repository_camere.Getall();
            return View(Repository_camere.lista_camere);
        }

        public ActionResult Admin_clienti()
        {
            try
            {
                if (t.Id != null)
                {
                    _db.Tabel_clienti.Add(t);
                    _db.SaveChanges();
                }
            }
            catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            Repository_clienti.Getall();
            return View(Repository_clienti.lista_clienti);
        }
    }
}