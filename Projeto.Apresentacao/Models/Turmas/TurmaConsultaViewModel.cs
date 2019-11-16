using Projeto.Repositorios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Apresentacao.Models.Turmas
{
    public class TurmaConsultaViewModel
    {
        public int         IdTurma { get; set; }
        public string      Nome    { get; set; }
        public List<Aluno> Alunos  { get; set; }
    }
}