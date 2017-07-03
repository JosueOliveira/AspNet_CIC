namespace Petbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upcater : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias");
            DropPrimaryKey("dbo.Categorias");
            AddColumn("dbo.Categorias", "CategoriaID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categorias", "CategoriaID");
            AddForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
            DropColumn("dbo.Categorias", "CategoriaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorias", "CategoriaID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias");
            DropPrimaryKey("dbo.Categorias");
            DropColumn("dbo.Categorias", "CategoriaID");
            AddPrimaryKey("dbo.Categorias", "CategoriaID");
            AddForeignKey("dbo.Animals", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
        }
    }
}
