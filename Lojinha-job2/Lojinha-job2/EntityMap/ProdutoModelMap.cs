using Lojinha_job2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Lojinha_job2.EntityMap
{
    public class ProdutoModelMap : EntityTypeConfiguration<ProdutoModel>

    {
        public ProdutoModelMap() {

            ToTable("Produto");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Ativo);
            Property(p => p.Nome).HasMaxLength(255).IsRequired();
    
        }

    }
}