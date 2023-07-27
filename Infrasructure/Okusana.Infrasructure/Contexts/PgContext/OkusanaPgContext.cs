using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using System.Reflection;

namespace Okusana.Infrasructure.Contexts.PgContext
{
    public class OkusanaPgContext : DbContext
    {
        public OkusanaPgContext() { }
        public OkusanaPgContext(DbContextOptions<OkusanaPgContext> options) : base(options) { }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<HashTag> HashTags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql("Server=127.0.0.1;Port=5432;Database=OkusnaPgDb;User Id=postgres;Password=123456;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Turkish_Turkey.1254");
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
