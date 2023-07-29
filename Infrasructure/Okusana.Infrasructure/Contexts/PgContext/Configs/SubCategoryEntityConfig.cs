using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okusana.Entities.Base;
using Okusana.Constants;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class SubCategoryEntityConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.SubCategories));
            entity.HasIndex(e => new { e.Name });

            entity.Property(e => e.Name)
               .IsRequired(DbSettings.SubCategory.Name.Required)
               .HasMaxLength(DbSettings.SubCategory.Name.Length)
               .IsUnicode(false)
               .HasComment("SubCategory adlari");

            entity.Property(e => e.Description)
              .IsRequired(DbSettings.SubCategory.Describtion.Required)
              .HasMaxLength(DbSettings.SubCategory.Describtion.Length)
              .IsUnicode(false)
              .HasComment("category aciklamasi");

            entity.HasOne(e => e.Category).WithMany(e => e.SubCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_SubCategory_Category");
        }
    }
}
