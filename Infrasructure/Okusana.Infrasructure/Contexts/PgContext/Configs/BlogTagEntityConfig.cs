using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Constants;
using Okusana.Entities.Base;
using Okusana.Entities.Concrete;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class BlogTagEntityConfig : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.BlogTags));

            entity.HasIndex(e => new { e.TagId, e.BlogId });

            entity.Property(e => e.TagId).IsRequired(DbSettings.BlogTag.HashTagId.Required);
            entity.Property(e => e.BlogId).IsRequired(DbSettings.BlogTag.BlogId.Required);

            entity.HasOne(e => e.Blog).WithMany(e => e.BlogTags)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_BlogTag_Blog");
            entity.HasOne(e => e.HashTag).WithMany(e => e.BlogTags)
                .HasForeignKey(e => e.TagId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_BlogTag_HashTag");
        }
    }
}
