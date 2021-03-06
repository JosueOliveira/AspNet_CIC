namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoTableProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "CategoriaID" });
            DropTable("dbo.Produtos");
        }
    }
}
