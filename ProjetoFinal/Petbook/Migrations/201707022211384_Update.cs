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
            RenameColumn(table: "dbo.Animals", name: "categoria_CategoriaID", newName: "CategoriaID");
            AlterColumn("dbo.Animals", "CategoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "CategoriaID");
            AddForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Animals", new[] { "CategoriaID" });
            AlterColumn("dbo.Animals", "CategoriaID", c => c.Int());
            RenameColumn(table: "dbo.Animals", name: "CategoriaID", newName: "categoria_CategoriaID");
            CreateIndex("dbo.Animals", "categoria_CategoriaID");
            AddForeignKey("dbo.Animals", "categoria_CategoriaID", "dbo.Categorias", "CategoriaID");
        }
    }
}
