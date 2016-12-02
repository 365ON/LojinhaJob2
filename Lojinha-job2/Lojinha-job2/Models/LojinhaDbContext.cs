using Lojinha_job2.EntityMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Lojinha_job2.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class LojinhaDbContext : DbContext
    {
        public LojinhaDbContext() : base("MysqlConnection")
        {
                
        }

        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<CategoriaProdutoModel> CategoriaProduto { get; set; }
        public DbSet<ComentarioProdutoModel> ComentarioProduto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LojinhaDbContext>(new CreateDatabaseIfNotExists<LojinhaDbContext>());

            modelBuilder.Configurations.Add(new ProdutoModelMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}