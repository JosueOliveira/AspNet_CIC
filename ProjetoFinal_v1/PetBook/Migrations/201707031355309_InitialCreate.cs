namespace PetBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(),
                        Ativo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        NomePet = c.String(),
                        IdadePet = c.Int(nullable: false),
                        DonoPet = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Pets", new[] { "CategoriaID" });
            DropTable("dbo.Pets");
            DropTable("dbo.Categorias");
        }
    }
}
