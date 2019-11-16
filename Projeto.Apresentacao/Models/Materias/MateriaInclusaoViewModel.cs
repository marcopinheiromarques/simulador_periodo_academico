using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Apresentacao.Models.Materias
{
    public class MateriaInclusaoViewModel
    {
        public string  Nome       { get; set; }
        public decimal PesoProva1 { get; set; }
        public decimal PesoProva2 { get; set; }
        public decimal PesoProva3 { get; set; }
    }
}