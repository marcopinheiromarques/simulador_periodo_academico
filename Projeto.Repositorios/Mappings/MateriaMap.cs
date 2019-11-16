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
    public class MateriaMap : EntityTypeConfiguration<Materia>
    {
        public MateriaMap()
        {
            //nome da tabela
            ToTable("MATERIA");

            //chave primária
            HasKey(m => m.IdMateria);

            //mapear os campos da tabela
            Property(m => m.IdMateria)
                .HasColumnName("IDMATERIA")
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(m => m.PesoProva1)
                .HasColumnName("PESOPROVA1")
                .IsRequired();

            Property(m => m.PesoProva2)
                .HasColumnName("PESOPROVA2")
                .IsRequired();

            Property(m => m.PesoProva3)
                .HasColumnName("PESOPROVA3")
                .IsRequired();
        }
    }
}
