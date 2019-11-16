using Projeto.Apresentacao.Models.Alunos;
using Projeto.Apresentacao.Models.Turmas;
using Projeto.Repositorios.Entidades;
using Projeto.Repositorios.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Apresentacao.Controllers
{
    public class TurmaController : Controller
    {
        [HttpGet]
        public JsonResult ConsultarTurmas()
        {
            try
            {
                List<TurmaConsultaViewModel> lista    = new List<TurmaConsultaViewModel>();
                TurmaRepository              turmaRep = new TurmaRepository();

                foreach (Turma turma in turmaRep.FindAll())
                {
                    lista.Add(new TurmaConsultaViewModel()
                    {
                        IdTurma = turma.IdTurma,
                        Nome    = turma.Nome                                                
                    });
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ConsultarAlunosDaTurma(int id)
        {
            try
            {
                TurmaRepository turmaRep = new TurmaRepository();
                Turma           t        = turmaRep.FindByIdWithAlunos(id);

                List<AlunoConsultaViewModel> lista = new List<AlunoConsultaViewModel>();

                foreach (Aluno aluno in t.Alunos)
                {
                    lista.Add(new AlunoConsultaViewModel()
                    {
                        IdAluno = aluno.IdAluno,
                        Nome    = aluno.Nome
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
        public JsonResult InserirTurmas(TurmasInclusaoViewModel model)
        {
            try
            {
                List<Turma> turmas  = new List<Turma>();
                int         idAluno = 1;

                //Adiciona as turmas
                for (int i = 1; i <= model.qtd_turmas; i++)
                {
                    Turma turma = new Turma();
                    turma.Nome  = $"Turma_{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt")}_{i}";
                    turmas.Add(turma);
                }

                TurmaRepository turmaRep = new TurmaRepository();
                AlunoRepository alunoRep = new AlunoRepository();

                foreach (Turma t in turmas)
                {
                    turmaRep.Insert(t);

                    //adiciona os alunos da turma
                    for (int i = 1; i <= model.qtd_alunos_turma; i++)
                    {
                        Aluno aluno   = new Aluno();
                        aluno.IdTurma = t.IdTurma;
                        aluno.Nome    = $"Aluno_{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt")}_{i}";

                        alunoRep.Insert(aluno);

                        idAluno++;
                    }
                }  

                return Json("Turmas inseridas com sucesso!");

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}