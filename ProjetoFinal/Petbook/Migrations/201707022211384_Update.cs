namespace Petbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Animals", new[] { "categoria_CategoriaID" });
            RenameColumn(table: "dbo.Animals", name: "categoria_CategoriaID", newName: "IdCat");
            AlterColumn("dbo.Animals", "IdCat", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "IdCat");
            AddForeignKey("dbo.Animals", "IdCat", "dbo.Categorias", "IdCat", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "IdCat", "dbo.Categorias");
            DropIndex("dbo.Animals", new[] { "IdCat" });
            AlterColumn("dbo.Animals", "IdCat", c => c.Int());
            RenameColumn(table: "dbo.Animals", name: "IdCat", newName: "categoria_CategoriaID");
            CreateIndex("dbo.Animals", "categoria_CategoriaID");
            AddForeignKey("dbo.Animals", "categoria_CategoriaID", "dbo.Categorias", "IdCat");
        }
    }
}
