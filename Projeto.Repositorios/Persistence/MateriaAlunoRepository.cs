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
    public class MateriaAlunoRepository : GenericRepository<MateriaAluno>
    {
        public List<MateriaAluno> FindAllByIdAluno(int idAluno)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<MateriaAluno>().Where(ma => ma.IdAluno == idAluno).ToList();                    
            }
        }
    }
}
