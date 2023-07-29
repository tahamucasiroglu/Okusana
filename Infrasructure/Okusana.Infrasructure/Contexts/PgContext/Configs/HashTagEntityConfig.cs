using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using Okusana.Entities.Base;
using Okusana.Constants;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class HashTagEntityConfig : IEntityTypeConfiguration<HashTag>
    {
        public void Configure(EntityTypeBuilder<HashTag> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.HashTags));
            //entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Name, e.CreateDate, e.IsDeleted });
            //entity.HasQueryFilter(e => !e.IsDeleted);
            //entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");

            entity.Property(e => e.Name)
                .IsRequired(DbSettings.HashTag.Name.Required)
                .HasMaxLength(DbSettings.HashTag.Name.Length)
                .IsUnicode(false)
                .HasComment("etiket ismi");
        }
    }
}
