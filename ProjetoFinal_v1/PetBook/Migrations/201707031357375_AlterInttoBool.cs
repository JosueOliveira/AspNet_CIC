namespace PetBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterInttoBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categorias", "Ativo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categorias", "Ativo", c => c.Int(nullable: false));
        }
    }
}
