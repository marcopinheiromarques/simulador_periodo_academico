using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Entidades
{
    public class Turma
    {
        public virtual int         IdTurma { get; set; }
        public virtual string      Nome    { get; set; }
        public virtual List<Aluno> Alunos  { get; set; }

        public Turma()
        {
            this.Alunos = new List<Aluno>();
        }
    }
}
