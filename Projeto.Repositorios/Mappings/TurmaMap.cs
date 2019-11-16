using Projeto.Repositorios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Mappings
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            //nome da tabela
            ToTable("TURMA");

            //chave primária
            HasKey(t => t.IdTurma);

            //mapear os campos da tabela
            Property(t => t.IdTurma)
                .HasColumnName("IDTURMA")
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            //Relacionamentos
            HasMany(t => t.Alunos) 
                .WithRequired(a => a.Turma)
                .HasForeignKey(t => t.IdTurma)
                .WillCascadeOnDelete(false);
        }
    }
}
