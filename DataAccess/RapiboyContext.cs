using RapiChallenge.Entities;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RapiChallenge.DataAccess
{
    public class RapiboyContext : DbContext
    {
        public RapiboyContext() : base("cs")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RapiboyContext>());
            Database.CommandTimeout = 0;
        }

        public RapiboyContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        public static RapiboyContext Create()
        {
            return new RapiboyContext();
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}