using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Entidades
{
    public class Materia
    {
        public virtual int                IdMateria      { get; set; }
        public virtual string             Nome           { get; set; }
        public virtual decimal            PesoProva1     { get; set; }
        public virtual decimal            PesoProva2     { get; set; }
        public virtual decimal            PesoProva3     { get; set; }
        public virtual List<MateriaAluno> MateriasAlunos { get; set; }
    }
}
