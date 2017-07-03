namespace Petbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Dono = c.String(),
                        categoria_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalID)
                .ForeignKey("dbo.Categorias", t => t.categoria_CategoriaID)
                .Index(t => t.categoria_CategoriaID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Animals", new[] { "categoria_CategoriaID" });
            DropTable("dbo.Categorias");
            DropTable("dbo.Animals");
        }
    }
}
