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
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            //nome da tabela
            ToTable("ALUNO");

            //chave primária
            HasKey(a => a.IdAluno);

            //mapear os campos da tabela
            Property(a => a.IdAluno)
                .HasColumnName("IDALUNO")
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
