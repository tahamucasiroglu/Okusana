using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Okusana.Entities.Concrete;
using Okusana.Entities.Base;
using Okusana.Constants.DbSettingConstants;

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


            entity.Property(e => e.Title)
                .IsRequired(BlogDbSettingsConstant.BlogTitleIsRequired)
                .HasMaxLength(BlogDbSettingsConstant.BlogTitleLength)
                .IsUnicode(BlogDbSettingsConstant.BlogTitleIsUnicode)
                .HasComment(BlogDbSettingsConstant.BlogTitleComment);

            entity.Property(e => e.Content)
                .HasColumnType(BlogDbSettingsConstant.BlogContentColumnType)
                .IsRequired(BlogDbSettingsConstant.BlogContentIsRequired)
                .HasMaxLength(BlogDbSettingsConstant.BlogContentLength) //blog yazacak roman değil 3000 çok adama olana :)
                .HasComment(BlogDbSettingsConstant.BlogContentComment);

            entity.Property(e => e.PublicationDate)
                .HasColumnType(BlogDbSettingsConstant.BlogPublicationDateColumnType)// saatine göre yayın için datetime dedim
                .IsRequired(BlogDbSettingsConstant.BlogPublicationDateIsRequired)
                .HasComment(BlogDbSettingsConstant.BlogPublicationDateComment);

            entity.Property(e => e.IsPublished)
                .IsRequired(BlogDbSettingsConstant.BlogIsPublishedIsRequired)
                .HasComment(BlogDbSettingsConstant.BlogIsPublishedComment);

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
