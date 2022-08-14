namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productoañadido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Imagen = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdUsuario);
            
            AddColumn("dbo.Rol", "Redirect", c => c.String());
            DropColumn("dbo.Rol", "Reidrect");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rol", "Reidrect", c => c.String());
            DropForeignKey("dbo.Producto", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Producto", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.Producto", new[] { "IdUsuario" });
            DropIndex("dbo.Producto", new[] { "IdCategoria" });
            DropColumn("dbo.Rol", "Redirect");
            DropTable("dbo.Producto");
        }
    }
}
