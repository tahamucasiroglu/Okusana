﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okusana.Entities.Base;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class BlogEntityConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            entity.ToTable(nameof(OkusanaPgContext.Blogs));
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Title);

            entity.Property(e => e.Title)
                .IsRequired(true)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Blog başlığı 150 karakter sınırı var");

            entity.Property(e => e.Content)
                .HasColumnType("text")
                .IsRequired(true)
                .HasMaxLength(3000) //blog yazacak roman değil 3000 çok adama olana :)
                .HasComment("blog gövdesi 3000 karakter sınırı var");

            entity.Property(e => e.PublicationDate)
                .HasColumnType("datetime")// saatine göre yayın için datetime dedim
                .IsRequired(true)
                .HasComment("isteğe bağlı yayınlanma tarihi");

            entity.HasOne(e => e.User).WithMany(e => e.Blogs)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Blogs_Users");

            entity.HasOne(e => e.Category).WithMany(e => e.Blogs)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Blogs_Categories");

        }
    }
}
