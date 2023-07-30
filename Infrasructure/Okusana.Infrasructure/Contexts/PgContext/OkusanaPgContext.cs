using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Base;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Extensions;

namespace Okusana.Infrasructure.Contexts.PgContext
{
    public class OkusanaPgContext : DbContext
    {
        public OkusanaPgContext() { }
        public OkusanaPgContext(DbContextOptions<OkusanaPgContext> options) : base(options) { }

        virtual public DbSet<Entity> Entities { get; set; }
        virtual public DbSet<Blog> Blogs { get; set; }
        virtual public DbSet<Category> Categories { get; set; }
        virtual public DbSet<SubCategory> SubCategories { get; set; }
        virtual public DbSet<Comment> Comments { get; set; }
        virtual public DbSet<HashTag> HashTags { get; set; }
        virtual public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            //.UseNpgsql("Server=127.0.0.1;Port=5432;Database=OkusnaPgDb;User Id=postgres;Password=123456;")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseTurkishPostgreSql();
            modelBuilder.GetAllConfigsAuto();
            //modelBuilder.Seeding(); //hata veriyor çözemedim sinirlenmemek için saldım.
            base.OnModelCreating(modelBuilder);
        }
    }
}
