using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Entidades
{
    public class Aluno
    {
        public virtual int                IdAluno        { get; set; }
        public virtual string             Nome           { get; set; }
        public virtual int                IdTurma        { get; set; }
        public virtual Turma              Turma          { get; set; }
        public virtual List<MateriaAluno> MateriasAlunos { get; set; }
    }
}
