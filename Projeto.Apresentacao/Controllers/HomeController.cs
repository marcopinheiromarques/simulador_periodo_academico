using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.TituloJanela = "Home";
            return View();
        }

        public ActionResult Turmas()
        {
            ViewBag.TituloJanela = "Turmas";
            return View();
        }

        public ActionResult Materias()
        {
            ViewBag.TituloJanela = "Matérias";
            return View();
        }

        public ActionResult Simulacao()
        {
            ViewBag.TituloJanela = "Simulação";
            return View();
        }
    }
}