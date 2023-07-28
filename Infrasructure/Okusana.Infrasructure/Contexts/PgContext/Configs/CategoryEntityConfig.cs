using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Entities.Base;
using Okusana.Entities.Concrete;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.Categories));
            //entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Name });
            //entity.HasQueryFilter(e => !e.IsDeleted);
            //entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");

            entity.Property(e => e.Name)
               .IsRequired(true)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasComment("kategori adlari");

            entity.Property(e => e.Description)
               .IsRequired(false)
               .HasMaxLength(150)
               .IsUnicode(false)
               .HasComment("category aciklamasi");
        }
    }
}
