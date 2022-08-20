namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminadoautogenerarfechaenProducto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "FechaCreacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
