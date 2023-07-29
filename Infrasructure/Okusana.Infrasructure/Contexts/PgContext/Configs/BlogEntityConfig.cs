using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using Okusana.Entities.Base;
using Okusana.Constants;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class BlogEntityConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.Blogs));
            //entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Title, e.IsPublished, e.CreateDate, e.IsDeleted });
            //entity.HasQueryFilter(e => e.IsPublished); // artık mecbur her where e yazacan
            //entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");
            //unit of work desing pattern çevirir. dbcontext ezmeli.

            entity.Property(e => e.UserId).IsRequired(DbSettings.Blog.UserId.Required);//bu ve altı gereksiz ama buralr olurda değişirse fluent validationda da göstermek için yaptım kaldırırm olmadı koyma amacım anlık değil ömürlük olarak bilgi vermek başkası bakınca hata atacağı için anlayacak tabi dökğman yazsamda olurdu
            entity.Property(e => e.SubCategoryId).IsRequired(DbSettings.Blog.SubCategoryId.Required);

            entity.Property(e => e.Title)
                .IsRequired(DbSettings.Blog.Title.Required)
                .HasMaxLength(DbSettings.Blog.Title.Length)
                .IsUnicode(false)
                .HasComment("Blog başlığı 150 karakter sınırı var");

            entity.Property(e => e.Content)
                .HasColumnType("text")
                .IsRequired(DbSettings.Blog.Content.Required)
                .HasMaxLength(DbSettings.Blog.Content.Length) //blog yazacak roman değil 3000 çok adama olana :)
                .HasComment("blog gövdesi 3000 karakter sınırı var");

            entity.Property(e => e.PublicationDate)
                .HasColumnType("timestamp with time zone")// saatine göre yayın için datetime dedim
                .IsRequired(DbSettings.Blog.PublicationDate.Required)
                .HasComment("isteğe bağlı yayınlanma tarihi");

            entity.Property(e => e.IsPublished)
                .IsRequired(DbSettings.Blog.IsPublished.Required)
                .HasComment("yayınlanma durumunu verir");

            entity.HasOne(e => e.User).WithMany(e => e.Blogs)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Blog_User");

            entity.HasOne(e => e.SubCategory).WithMany(e => e.Blogs)
                .HasForeignKey(e => e.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Blog_SubCategories");

        }
    }
}
