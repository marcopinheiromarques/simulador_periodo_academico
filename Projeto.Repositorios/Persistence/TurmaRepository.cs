using Projeto.Repositorios.Context;
using Projeto.Repositorios.Entidades;
using Projeto.Repositorios.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Projeto.Repositorios.Persistence
{
    public class TurmaRepository : GenericRepository<Turma>
    {
        public Turma FindByIdWithAlunos(int idTurma)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<Turma>()
                    .Include(t => t.Alunos)
                    .SingleOrDefault(t => t.IdTurma == idTurma);                    
            }
        }
    }
}
