using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using Okusana.Entities.Base;
using Okusana.Constants;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.Comments));
            //entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Rate, e.CreateDate, e.IsDeleted });
            //entity.HasQueryFilter(e => !e.IsDeleted);
            //entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");

            entity.Property(e => e.Content)
                .IsRequired(DbSettings.Comment.Content.Required)
                .HasColumnType("text")
                .HasMaxLength(DbSettings.Comment.Content.Length)
                .IsUnicode(false)
                .HasComment("kullanıcı yorum yazısı");

            entity.Property(e => e.Rate)
                .IsRequired(DbSettings.Comment.Rate.Required)
                .HasComment("kullanıcı puan değeri 5 üzerinden olur bir değişiklik olmazsa");

            entity.HasOne(e => e.Blog).WithMany(e => e.Comments)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Comment_Blog");

            entity.HasOne(e => e.User).WithMany(e => e.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Comment_User");
        }
    }
}
