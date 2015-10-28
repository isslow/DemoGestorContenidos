using GestorContenido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorContenido.Controllers
{
    public class HomeController : Controller
    {
        private EntityModel context = new EntityModel();
        string mensajeError = "";
        Contenido modelCont = new Contenido();
        public ActionResult Index()
        {
            try
            {
                //modelCont=
                return View(context.Contenido.ToList());
            }catch(Exception e)
            {
                mensajeError = e.Message;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}