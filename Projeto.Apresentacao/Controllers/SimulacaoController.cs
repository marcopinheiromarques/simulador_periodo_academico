using Projeto.Apresentacao.Models.Simulacao;
using Projeto.Repositorios.Entidades;
using Projeto.Repositorios.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Apresentacao.Controllers
{
    public class SimulacaoController : Controller
    {
        [HttpPost]
        public JsonResult Simular()
        {
            try
            {
                ISimulacaoPeriodoAcademico simulador = new SimulacaoPeriodoAcademico();
                simulador.Simular();

                return Json("Simulação realizada com sucesso!");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpGet]
        public JsonResult ConsultarSimulacao()
        {
            try
            {
                List<SimulacaoConsultaViewModel> lista           = new List<SimulacaoConsultaViewModel>();
                MateriaAlunoRepository           materiaAlunoRep = new MateriaAlunoRepository();
                TurmaRepository                  turmaRep        = new TurmaRepository();
                AlunoRepository                  alunoRep        = new AlunoRepository();
                ISimulacaoPeriodoAcademico       simulador       = new SimulacaoPeriodoAcademico();

                List<MateriaAluno> ma = materiaAlunoRep.FindAll();

                if (ma.Count() > 0)
                {
                    foreach (Aluno aluno in alunoRep.FindAll())
                    {
                        SimulacaoConsultaViewModel sc = new SimulacaoConsultaViewModel();
                        Turma turma = turmaRep.FindById(aluno.IdTurma);

                        sc.IdAluno = aluno.IdAluno;
                        sc.NomeAluno = aluno.Nome;
                        sc.NomeTurma = turma.Nome;
                        sc.Situacao = simulador.ObterSituacaoPeriodoAcademicoAluno(sc.IdAluno);

                        lista.Add(sc);
                    }
                }             


                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ConsultarDetalhesProvasAluno(int id)
        {
            try
            {
                List<DetalheProvasAlunoViewModel> detalhes = new List<DetalheProvasAlunoViewModel>();

                MateriaAlunoRepository     materiaAlunoRep = new MateriaAlunoRepository();
                MateriaRepository          materiaRep      = new MateriaRepository();
                ISimulacaoPeriodoAcademico simulador       = new SimulacaoPeriodoAcademico();

                foreach (MateriaAluno ma in materiaAlunoRep.FindAllByIdAluno(id))
                {
                    DetalheProvasAlunoViewModel d       = new DetalheProvasAlunoViewModel();
                    Materia                     materia = materiaRep.FindById(ma.IdMateria);

                    if (materia != null)
                    {
                        d.NomeMateria    = materia.Nome;
                        d.Prova1         = Math.Round(ma.NotaProva1    , 1);
                        d.Prova2         = Math.Round(ma.NotaProva2    , 1);
                        d.Prova3         = Math.Round(ma.NotaProva3    , 1);
                        d.ProvaFinal     = Math.Round(ma.NotaProvaFinal, 1);

                        d.MediaPonderada = simulador.CalcularMediaPonderada(
                            d.Prova1, d.Prova2, d.Prova3, materia.PesoProva1, 
                            materia.PesoProva2, materia.PesoProva3);

                        if (simulador.VerificaSeFazProvaFinal(d.MediaPonderada))
                        {
                            d.MediaAritmetica = simulador.CalcularMediaAritmetica(
                                d.MediaPonderada, d.ProvaFinal);
                        }

                        d.Situacao = simulador.ObterSituacaoMateria(d.MediaPonderada, d.MediaAritmetica);
                    }

                    detalhes.Add(d);
                }

                return Json(detalhes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}