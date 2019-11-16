using Projeto.Repositorios.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repositorios.Mappings
{
    public class MateriaAlunoMap : EntityTypeConfiguration<MateriaAluno>
    {
        public MateriaAlunoMap()
        {
            //nome da tabela
            ToTable("MATERIAALUNO");

            //chave 
            HasKey(ma => new { ma.IdMateria, ma.IdAluno });

            //mapear os campos da tabela
            Property(ma => ma.IdMateria)
                .HasColumnName("IDMATERIA")
                .IsRequired();

            Property(ma => ma.IdAluno)
                .HasColumnName("IDALUNO")
                .IsRequired();

            Property(ma => ma.NotaProva1)
                .HasColumnName("NOTAPROVA1")
                .IsRequired();

            Property(ma => ma.NotaProva2)
                .HasColumnName("NOTAPROVA2")
                .IsRequired();

            Property(ma => ma.NotaProva3)
                .HasColumnName("NOTAPROVA3")
                .IsRequired();

            Property(ma => ma.NotaProvaFinal)
                .HasColumnName("NOTAPROVAFINAL")
                .IsRequired();

            //Relacionamentos
            HasRequired(ma => ma.Materia)
                .WithMany(m => m.MateriasAlunos)
                .HasForeignKey(ma => ma.IdMateria)
                .WillCascadeOnDelete(false);

            HasRequired(ma => ma.Aluno)
                .WithMany(a => a.MateriasAlunos)
                .HasForeignKey(ma => ma.IdAluno)
                .WillCascadeOnDelete(false);
        }
    }
}
