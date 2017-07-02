namespace PetBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalsCategoria : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categorias", new[] { "Animal_AnimalID" });
            RenameColumn(table: "dbo.Animals", name: "Animal_AnimalID", newName: "categoria_CategoriaID");
            CreateIndex("dbo.Animals", "categoria_CategoriaID");
            DropColumn("dbo.Categorias", "Animal_AnimalID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorias", "Animal_AnimalID", c => c.Int());
            DropIndex("dbo.Animals", new[] { "categoria_CategoriaID" });
            RenameColumn(table: "dbo.Animals", name: "categoria_CategoriaID", newName: "Animal_AnimalID");
            CreateIndex("dbo.Categorias", "Animal_AnimalID");
        }
    }
}
