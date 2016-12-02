namespace Lojinha_job2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaProdutoModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComentarioProdutoModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Conteudo = c.String(unicode: false),
                        Produto_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Categoria_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaProdutoModel", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComentarioProdutoModel", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.CategoriaProdutoModel");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropIndex("dbo.ComentarioProdutoModel", new[] { "Produto_Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.ComentarioProdutoModel");
            DropTable("dbo.CategoriaProdutoModel");
        }
    }
}
