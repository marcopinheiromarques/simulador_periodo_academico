using Projeto.Apresentacao.Models.Materias;
using Projeto.Repositorios.Entidades;
using Projeto.Repositorios.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Apresentacao.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult ConsultarMaterias()
        {
            try
            {
                List<MateriaConsultaViewModel> lista      = new List<MateriaConsultaViewModel>();
                MateriaRepository              materiaRep = new MateriaRepository();

                foreach (Materia materia in materiaRep.FindAll())
                {
                    lista.Add(new MateriaConsultaViewModel()
                    {
                        IdMateria  = materia.IdMateria,
                        Nome       = materia.Nome,
                        PesoProva1 = materia.PesoProva1,
                        PesoProva2 = materia.PesoProva2,
                        PesoProva3 = materia.PesoProva3
                    });
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InserirMateria(MateriaInclusaoViewModel model)
        {
            try
            {
                Materia materia    = new Materia();
                materia.Nome       = model.Nome;
                materia.PesoProva1 = model.PesoProva1;
                materia.PesoProva2 = model.PesoProva2;
                materia.PesoProva3 = model.PesoProva3;

                MateriaRepository materiaRep = new MateriaRepository();

                materiaRep.Insert(materia);

                return Json("Matéria inserida com sucesso!");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}