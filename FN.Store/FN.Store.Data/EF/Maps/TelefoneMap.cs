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
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable("Tel");

            HasKey(k=>k.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.NTel).HasColumnType("varchar").HasMaxLength(11).IsRequired();
            Property(c => c.ClienteId).HasColumnType("int");
            Property(c => c.DataCadastro).HasColumnType("date");

            //FK
            HasRequired(c => c.Cliente).WithMany(t => t.Telefones)
                .HasForeignKey(f => f.ClienteId);
        }
    }
}
