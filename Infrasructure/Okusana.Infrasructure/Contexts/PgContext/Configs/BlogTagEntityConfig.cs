using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Entities.Concrete;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class BlogTagEntityConfig : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.HasKey(e => new { e.TagId, e.BlogId });
            entity.HasOne(e => e.Blog).WithMany(e => e.BlogTags)
                .HasForeignKey(e => e.BlogId)
                .HasConstraintName("FK_BlogTag_Blog");
            entity.HasOne(e => e.HashTag).WithMany(e => e.BlogTags)
                .HasForeignKey(e => e.BlogId)
                .HasConstraintName("FK_BlogTag_HashTag");
        }
    }
}
