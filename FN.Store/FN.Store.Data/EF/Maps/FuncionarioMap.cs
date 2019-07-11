using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Maps
{
    class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {

            //Tabela
            ToTable("Funcionario");

            //PK
            HasKey(pk => pk.Id);
            //Chave Composta
            //HasKey(pk => new { pk.Id,pk.Nome });

            //Propriedades
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(c => c.CodFunc).HasColumnName("CodigoFuncionario").HasColumnType("uniqueidentifier");
            Property(c => c.DataCadastro).HasColumnType("date");

        }
    }
}
