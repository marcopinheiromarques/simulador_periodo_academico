using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Entidades
{
    public class MateriaAluno
    {
        public virtual int     IdMateria      { get; set; }
        public virtual Materia Materia        { get; set; }
        public virtual int     IdAluno        { get; set; }
        public virtual Aluno   Aluno          { get; set; }
        public virtual decimal NotaProva1     { get; set; }
        public virtual decimal NotaProva2     { get; set; }
        public virtual decimal NotaProva3     { get; set; }
        public virtual decimal NotaProvaFinal { get; set; }
    }
}
