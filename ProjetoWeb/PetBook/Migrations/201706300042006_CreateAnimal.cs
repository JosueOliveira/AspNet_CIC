namespace PetBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAnimal : DbMigration
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
                        categoria_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalID)
                .ForeignKey("dbo.Categorias", t => t.categoria_CategoriaID)
                .Index(t => t.categoria_CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Animals", new[] { "categoria_CategoriaID" });
            DropTable("dbo.Animals");
        }
    }
}
