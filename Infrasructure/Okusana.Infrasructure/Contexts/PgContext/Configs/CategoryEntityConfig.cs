using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Entities.Base;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.Categories));
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Name);

            entity.Property(e => e.Name)
               .IsRequired(true)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasComment("kategori adları");

            entity.Property(e => e.Description)
               .IsRequired(false)
               .HasMaxLength(150)
               .IsUnicode(false)
               .HasComment("category açıklaması");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Categories_Categories");

        }
    }
}
