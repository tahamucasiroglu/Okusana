using Microsoft.EntityFrameworkCore;
using Okusana.Constants;
using Okusana.Entities.Concrete;
using Okusana.Extensions;
using System.Text;

namespace Okusana.Infrasructure.Extensions
{
    static public class SeedingExtension
    {
        static public void Seeding(this ModelBuilder builder)
        {
            Guid sporId = Guid.NewGuid();
            Guid futbolId = Guid.NewGuid();
            Guid basketbolId = Guid.NewGuid();

            Guid amatorlig = Guid.NewGuid();
            Guid superlig = Guid.NewGuid();

            Guid teknolojiId = Guid.NewGuid();
            Guid bilgisayarId = Guid.NewGuid();
            Guid telefonId = Guid.NewGuid();

            Guid user1 = Guid.NewGuid();
            Guid user2 = Guid.NewGuid();
            Guid user3 = Guid.NewGuid();

            Guid topTag = Guid.NewGuid();
            Guid sporTag = Guid.NewGuid();
            Guid teknolojiTag = Guid.NewGuid();
            Guid moderTag = Guid.NewGuid();
            Guid sahaTag = Guid.NewGuid();
            Guid kasaTag = Guid.NewGuid();
            Guid laptopTag = Guid.NewGuid();
            Guid samsungTag = Guid.NewGuid();
            Guid iphoneTag = Guid.NewGuid();

            Guid blog1 = Guid.NewGuid();
            Guid blog2 = Guid.NewGuid();
            Guid blog3 = Guid.NewGuid();
            Guid blog4 = Guid.NewGuid();

            builder.Entity<Category>().HasData
            (
            #region kategoriler
                new Category
                {
                    Id = sporId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Spor",
                    Description = "Spor türündeki kategorileri içerir",
                    ParentId = null,
                },
                new Category
                {
                    Id = futbolId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Futbol",
                    Description = "Futbol yazıları",
                    ParentId = sporId,
                },
                new Category
                {
                    Id = basketbolId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Basketbol",
                    Description = "Basketbol yazıları",
                    ParentId = sporId,
                },
                new Category
                {
                    Id = amatorlig,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Amatör Lig",
                    Description = "Amatör futbol ligi",
                    ParentId = futbolId,
                },
                new Category
                {
                    Id = superlig,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Süperlig",
                    Description = "Süperlig yazıları",
                    ParentId = futbolId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Türkiye",
                    Description = "Türkiye baskett yazıları",
                    ParentId = basketbolId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "NBA",
                    Description = "NBA basket yazıları",
                    ParentId = basketbolId,
                },





                new Category
                {
                    Id = teknolojiId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Teknoloji",
                    Description = "Teknoloji yazıları içerir",
                    ParentId = null,
                },
                new Category
                {
                    Id = bilgisayarId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Bilgisayar",
                    Description = "Bilgisayar yazıları",
                    ParentId = teknolojiId,
                },
                new Category
                {
                    Id = telefonId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Laptop",
                    Description = "Laptop yazıları",
                    ParentId = teknolojiId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Ekran kartı",
                    Description = "Ekran kartı yazıları",
                    ParentId = bilgisayarId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "İşlemci",
                    Description = "İşlemci yazıları",
                    ParentId = bilgisayarId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Amiral gemisi telefon",
                    Description = "Amiral gemisi telefon yazıları",
                    ParentId = telefonId,
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Orta segment telefon",
                    Description = "Orta segment telefon yazıları",
                    ParentId = telefonId,
                }
            #endregion
            );
            builder.Entity<User>().HasData
            (
            #region Üyeler
            new User
            {
                Id = user1,
                CreateDate = DateTime.UtcNow,
                UpdateDate = null,
                DeleteDate = null,
                IsDeleted = false,
                Name = "Admin Taha",
                Surname = "mücasiroğlu",
                Email = "ataha@gmail.com",
                Phone = null,
                IdentityNumber = null,
                BirthDate = DateTime.UtcNow.AddYears(-20),
                Gender = false,
                Password = "123456".ToSha256(),
                Status = UserStatusConstant.Admin,
            },
                new User
                {
                    Id = user2,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Editor Taha",
                    Surname = "mücasiroğlu",
                    Email = "etaha@gmail.com",
                    Phone = null,
                    IdentityNumber = null,
                    BirthDate = DateTime.UtcNow.AddYears(-30),
                    Gender = false,
                    Password = "123456".ToSha256(),
                    Status = UserStatusConstant.Editor,
                },
                new User
                {
                    Id = user3,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Member Taha",
                    Surname = "mücasiroğlu",
                    Email = "mtaha@gmail.com",
                    Phone = null,
                    IdentityNumber = null,
                    BirthDate = DateTime.UtcNow.AddYears(-40),
                    Gender = false,
                    Password = "123456".ToSha256(),
                    Status = UserStatusConstant.Member,
                }
                #endregion
            );
            builder.Entity<HashTag>().HasData
            (
            #region Hashtagler
            new HashTag
            {
                Id = topTag,
                CreateDate = DateTime.UtcNow,
                UpdateDate = null,
                DeleteDate = null,
                IsDeleted = false,
                Name = "Top",
            },
                new HashTag
                {
                    Id = sporTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Spor",
                },
                new HashTag
                {
                    Id = teknolojiTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Teknoloji",
                },
                new HashTag
                {
                    Id = moderTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Modern",
                },
                new HashTag
                {
                    Id = sahaTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Saha",
                },
                new HashTag
                {
                    Id = kasaTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Kasa",
                },
                new HashTag
                {
                    Id = laptopTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Laptop",
                },
                new HashTag
                {
                    Id = samsungTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Samsung",
                },
                new HashTag
                {
                    Id = iphoneTag,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Name = "Iphone",
                }
                #endregion
            );
            builder.Entity<Blog>().HasData
            (
            #region Blog
                new Blog
                {
                    Id = blog1,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Title = "amatör Futboll",
                    Content = new StringBuilder().AppendJoin(separator: null, values: Enumerable.Repeat("Lorem ", 100)).ToString(),
                    PublicationDate = null,
                    IsPublished = true,
                    UserId = user1,
                    CategoryId = amatorlig,
                },
                new Blog
                {
                    Id = blog2,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Title = "Futboll süper",
                    Content = new StringBuilder().AppendJoin(separator: null, values: Enumerable.Repeat("Lorem ", 100)).ToString(),
                    PublicationDate = null,
                    IsPublished = true,
                    UserId = user2,
                    CategoryId = superlig,
                },
                new Blog
                {
                    Id = blog3,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    DeleteDate = null,
                    IsDeleted = false,
                    Title = "basket genel",
                    Content = new StringBuilder().AppendJoin(separator: null, values: Enumerable.Repeat("Lorem ", 100)).ToString(),
                    PublicationDate = null,
                    IsPublished = true,
                    UserId = user1,
                    CategoryId = basketbolId,
                }
                #endregion
            );
        }
    }
}
