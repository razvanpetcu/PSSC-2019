using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_CORE.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Admin_clienti()
        {
            return View();
        }
    }
}