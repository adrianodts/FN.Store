using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FN.Store.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FN.Store.Data.EF.Maps
{
    class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {

            //Tabela
            ToTable("Cliente");

            //PK
            HasKey(pk => pk.Id);
            //Chave Composta
            //HasKey(pk => new { pk.Id,pk.Nome });

            //Propriedades
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(c => c.Idade).HasColumnType("tinyint");
            Property(c => c.Sexo).HasColumnType("int");
            Property(c => c.DataCadastro).HasColumnType("date");

        }
    }
}
