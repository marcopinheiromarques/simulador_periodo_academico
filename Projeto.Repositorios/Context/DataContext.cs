using Projeto.Repositorios.Entidades;
using Projeto.Repositorios.Mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager
                  .ConnectionStrings["conexao"].ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new TurmaMap());
            modelBuilder.Configurations.Add(new MateriaMap());
            modelBuilder.Configurations.Add(new MateriaAlunoMap());
        }

        //Propriedades
        public DbSet<Aluno>        Aluno        { get; set; }
        public DbSet<Turma>        Turma        { get; set; }
        public DbSet<Materia>      Materia      { get; set; }
        public DbSet<MateriaAluno> MateriaAluno { get; set; }
    }
}
