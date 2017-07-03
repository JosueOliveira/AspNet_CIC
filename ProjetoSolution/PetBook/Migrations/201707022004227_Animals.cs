namespace PetBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animals : DbMigration
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
                        Proprietario = c.String(),
                    })
                .PrimaryKey(t => t.AnimalID);
            
            AddColumn("dbo.Categorias", "Animal_AnimalID", c => c.Int());
            CreateIndex("dbo.Categorias", "Animal_AnimalID");
            AddForeignKey("dbo.Categorias", "Animal_AnimalID", "dbo.Animals", "AnimalID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorias", "Animal_AnimalID", "dbo.Animals");
            DropIndex("dbo.Categorias", new[] { "Animal_AnimalID" });
            DropColumn("dbo.Categorias", "Animal_AnimalID");
            DropTable("dbo.Animals");
        }
    }
}
