using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Apresentacao.Models.Simulacao
{
    public class SimulacaoConsultaViewModel
    {
        public int    IdAluno   { get; set; }
        public string NomeAluno { get; set; }
        public string NomeTurma { get; set; }
        public string Situacao  { get; set; }
    }
}