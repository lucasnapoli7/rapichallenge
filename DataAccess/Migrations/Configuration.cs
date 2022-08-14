namespace DataAccess.Migrations
{
    using RapiChallenge.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RapiChallenge.DataAccess.RapiboyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            CommandTimeout = Int32.MaxValue;
        }

        protected override void Seed(RapiChallenge.DataAccess.RapiboyContext context)
        {
            context.Rol.AddOrUpdate(
            p => p.Nombre,
                new Rol { Nombre = "Administrador", Redirect = "/Producto" }
            );
            context.SaveChanges();

            context.Usuario.AddOrUpdate(
            p => p.Email,
                new Usuario { Email = "admin@gmail.com", Password = "123456", IdRol = context.Rol.First().Id }
            );
            context.SaveChanges();

            context.Categoria.AddOrUpdate(
            p => p.Nombre,
                new Categoria { Nombre = "Categoria 1" },
                new Categoria { Nombre = "Categoria 2" },
                new Categoria { Nombre = "Categoria 3" }
            );
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
