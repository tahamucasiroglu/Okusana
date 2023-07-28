using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okusana.Infrasructure.Migrations
{
    /// <inheritdoc />
    public partial class _13_mig_no_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false, comment: "kategori adlari"),
                    Description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true, comment: "category aciklamasi")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false, comment: "etiket ismi")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false, comment: "Üyelerin isimleri"),
                    Surname = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false, comment: "Üyelerin soy isimleri"),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false, comment: "Üyelerin mail adresleri"),
                    Phone = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true, comment: "Üyelerin telefon numaraları"),
                    IdentityNumber = table.Column<string>(type: "character varying(11)", unicode: false, maxLength: 11, nullable: true, comment: "Üyelerin kimlik nuamraları"),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Üyelerin doğum tarihleri"),
                    Gender = table.Column<bool>(type: "boolean", nullable: true, comment: "Üyelerin cinsiyetleri false erkek true kadın null belirtmek istemiyorum"),
                    Password = table.Column<string>(type: "character varying(64)", unicode: false, maxLength: 64, nullable: false, comment: "Üyelerin şifreleri sha 256 alınacak"),
                    Status = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false, comment: "Üyelerin rütbeleri")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false, comment: "SubCategory adlari"),
                    Description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true, comment: "category aciklamasi")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false, comment: "Blog başlığı 150 karakter sınırı var"),
                    Content = table.Column<string>(type: "text", maxLength: 3000, nullable: false, comment: "blog gövdesi 3000 karakter sınırı var"),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "isteğe bağlı yayınlanma tarihi"),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false, comment: "yayınlanma durumunu verir")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_SubCategories",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogTag",
                columns: table => new
                {
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => new { x.TagId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_BlogTag_Blog",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTag_HashTag",
                        column: x => x.BlogId,
                        principalTable: "HashTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", unicode: false, maxLength: 250, nullable: false, comment: "kullanıcı yorum yazısı"),
                    Rate = table.Column<int>(type: "integer", nullable: true, comment: "kullanıcı puan değeri 5 üzerinden olur bir değişiklik olmazsa"),
                    IsLike = table.Column<bool>(type: "boolean", nullable: false, comment: "kullanıcı beğenme durumu")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Blog",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_SubCategoryId",
                table: "Blogs",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title_IsPublished_CreateDate_IsDeleted",
                table: "Blogs",
                columns: new[] { "Title", "IsPublished", "CreateDate", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_BlogId",
                table: "BlogTag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Rate_IsLike_CreateDate_IsDeleted",
                table: "Comments",
                columns: new[] { "Rate", "IsLike", "CreateDate", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HashTags_Name_CreateDate_IsDeleted",
                table: "HashTags",
                columns: new[] { "Name", "CreateDate", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Name",
                table: "SubCategories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Email_CreateDate_IsDeleted",
                table: "Users",
                columns: new[] { "Id", "Email", "CreateDate", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
