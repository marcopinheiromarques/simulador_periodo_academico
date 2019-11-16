using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Apresentacao.Models.Simulacao
{
    public class DetalheProvasAlunoViewModel
    {
        public string  NomeMateria     { get; set; }
        public decimal Prova1          { get; set; }
        public decimal Prova2          { get; set; }
        public decimal Prova3          { get; set; }
        public decimal ProvaFinal      { get; set; }
        public decimal MediaPonderada  { get; set; }
        public decimal MediaAritmetica { get; set; }
        public string  Situacao        { get; set; }
    }
}