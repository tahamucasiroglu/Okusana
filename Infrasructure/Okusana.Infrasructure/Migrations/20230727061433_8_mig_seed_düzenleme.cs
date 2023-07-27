using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Okusana.Infrasructure.Migrations
{
    /// <inheritdoc />
    public partial class _8_mig_seed_düzenleme : Migration
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
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false, comment: "kategori adlari"),
                    Description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: true, comment: "category aciklamasi")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
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
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false, comment: "Blog başlığı 150 karakter sınırı var"),
                    Content = table.Column<string>(type: "text", maxLength: 3000, nullable: false, comment: "blog gövdesi 3000 karakter sınırı var"),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "isteğe bağlı yayınlanma tarihi"),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false, comment: "yayınlanma durumunu verir")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blogs_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogHashTag",
                columns: table => new
                {
                    BlogsId = table.Column<Guid>(type: "uuid", nullable: false),
                    HashTagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogHashTag", x => new { x.BlogsId, x.HashTagsId });
                    table.ForeignKey(
                        name: "FK_BlogHashTag_Blogs_BlogsId",
                        column: x => x.BlogsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogHashTag_HashTags_HashTagsId",
                        column: x => x.HashTagsId,
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "IsDeleted", "Name", "ParentId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("78332ec4-d928-4615-b67a-9ab0ca1e94b3"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4820), null, "Spor türündeki kategorileri içerir", false, "Spor", null, null },
                    { new Guid("cc1ab466-e4c0-4e19-9735-2fbb455239c2"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4841), null, "Teknoloji yazıları içerir", false, "Teknoloji", null, null }
                });

            migrationBuilder.InsertData(
                table: "HashTags",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "IsDeleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2960c0c2-ca47-4ce6-93e1-0eb146a08a98"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5273), null, false, "Top", null },
                    { new Guid("40fe298e-3e48-428d-8c6e-8ad47fa3502b"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5278), null, false, "Saha", null },
                    { new Guid("431ffa84-e935-4f16-b1c3-28293af8e055"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5275), null, false, "Spor", null },
                    { new Guid("4cf1e41f-45ff-4b36-9b6b-c8ff750c5d2e"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5283), null, false, "Iphone", null },
                    { new Guid("5c5dacb4-d3d6-43d9-b4a1-818c2595ab6b"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5279), null, false, "Kasa", null },
                    { new Guid("63e6efc0-7adb-40ed-857b-9ed1ab86411f"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5277), null, false, "Modern", null },
                    { new Guid("c686021c-c05b-412a-9407-d7fffaec27ac"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5281), null, false, "Laptop", null },
                    { new Guid("da6cb33b-a16f-4300-a736-5559d73666ba"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5276), null, false, "Teknoloji", null },
                    { new Guid("e9b8ee87-d7a6-4430-b2be-f6f85e5ab4ff"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5282), null, false, "Samsung", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreateDate", "DeleteDate", "Email", "Gender", "IdentityNumber", "IsDeleted", "Name", "Password", "Phone", "Status", "Surname", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2f90329e-0084-4c4a-a507-c384cf79213c"), new DateTime(2003, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4944), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4939), null, "ataha@gmail.com", false, null, false, "Admin Taha", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, "Admin", "mücasiroğlu", null },
                    { new Guid("678ba915-a2c6-40c9-9ccf-50348249632b"), new DateTime(1983, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5245), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5243), null, "mtaha@gmail.com", false, null, false, "Member Taha", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, "Member", "mücasiroğlu", null },
                    { new Guid("a4e760a9-d3e9-41b9-809c-acf00822e5f7"), new DateTime(1993, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5197), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5195), null, "etaha@gmail.com", false, null, false, "Editor Taha", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, "Editor", "mücasiroğlu", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "IsDeleted", "Name", "ParentId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("09cdc7ba-1d46-4ec5-8491-e4c9e68fb45c"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4842), null, "Bilgisayar yazıları", false, "Bilgisayar", new Guid("cc1ab466-e4c0-4e19-9735-2fbb455239c2"), null },
                    { new Guid("7a4bf1cd-6e44-4ba0-a5dd-1aa934e5405d"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4828), null, "Futbol yazıları", false, "Futbol", new Guid("78332ec4-d928-4615-b67a-9ab0ca1e94b3"), null },
                    { new Guid("b6477090-abe3-4be0-bf25-8da01170297a"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4831), null, "Basketbol yazıları", false, "Basketbol", new Guid("78332ec4-d928-4615-b67a-9ab0ca1e94b3"), null },
                    { new Guid("c57fbd94-8ae1-4727-a770-d69b224e52da"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4844), null, "Laptop yazıları", false, "Laptop", new Guid("cc1ab466-e4c0-4e19-9735-2fbb455239c2"), null }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreateDate", "DeleteDate", "IsDeleted", "IsPublished", "PublicationDate", "Title", "UpdateDate", "UserId" },
                values: new object[] { new Guid("b12032c3-506c-4528-8969-65b67f42c15a"), new Guid("b6477090-abe3-4be0-bf25-8da01170297a"), "Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem ", new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5372), null, false, true, null, "basket genel", null, new Guid("2f90329e-0084-4c4a-a507-c384cf79213c") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "IsDeleted", "Name", "ParentId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("010fa2a1-fa76-4111-9952-7a552a695ce5"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4846), null, "Ekran kartı yazıları", false, "Ekran kartı", new Guid("09cdc7ba-1d46-4ec5-8491-e4c9e68fb45c"), null },
                    { new Guid("31ad48b2-024e-4c15-bac7-709232e0e085"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4839), null, "NBA basket yazıları", false, "NBA", new Guid("b6477090-abe3-4be0-bf25-8da01170297a"), null },
                    { new Guid("5bec5d9a-3432-4550-b132-d6d5d791a7f6"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4834), null, "Süperlig yazıları", false, "Süperlig", new Guid("7a4bf1cd-6e44-4ba0-a5dd-1aa934e5405d"), null },
                    { new Guid("9244478d-cd75-4e31-93ab-fd808f655bee"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4851), null, "Orta segment telefon yazıları", false, "Orta segment telefon", new Guid("c57fbd94-8ae1-4727-a770-d69b224e52da"), null },
                    { new Guid("982ec29b-8ac0-4274-80b1-5f9f39714c25"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4832), null, "Amatör futbol ligi", false, "Amatör Lig", new Guid("7a4bf1cd-6e44-4ba0-a5dd-1aa934e5405d"), null },
                    { new Guid("a0dc2bf5-ebce-4f11-959b-14b3482fb9e6"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4837), null, "Türkiye baskett yazıları", false, "Türkiye", new Guid("b6477090-abe3-4be0-bf25-8da01170297a"), null },
                    { new Guid("e509a993-a291-45de-bcc7-0d05e0ed34bd"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4847), null, "İşlemci yazıları", false, "İşlemci", new Guid("09cdc7ba-1d46-4ec5-8491-e4c9e68fb45c"), null },
                    { new Guid("ee53a64f-8966-486a-bf7c-01e8ac26746b"), new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(4849), null, "Amiral gemisi telefon yazıları", false, "Amiral gemisi telefon", new Guid("c57fbd94-8ae1-4727-a770-d69b224e52da"), null }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "CreateDate", "DeleteDate", "IsDeleted", "IsPublished", "PublicationDate", "Title", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1aee5088-c4da-4f97-955a-f53092970988"), new Guid("982ec29b-8ac0-4274-80b1-5f9f39714c25"), "Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem ", new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5303), null, false, true, null, "amatör Futboll", null, new Guid("2f90329e-0084-4c4a-a507-c384cf79213c") },
                    { new Guid("1f1e00a1-b237-4eff-99d2-641a961fff2f"), new Guid("5bec5d9a-3432-4550-b132-d6d5d791a7f6"), "Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem Lorem ", new DateTime(2023, 7, 27, 6, 14, 33, 216, DateTimeKind.Utc).AddTicks(5357), null, false, true, null, "Futboll süper", null, new Guid("a4e760a9-d3e9-41b9-809c-acf00822e5f7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogHashTag_HashTagsId",
                table: "BlogHashTag",
                column: "HashTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Title_IsPublished_CreateDate_IsDeleted",
                table: "Blogs",
                columns: new[] { "Title", "IsPublished", "CreateDate", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name_CreateDate_IsDeleted",
                table: "Categories",
                columns: new[] { "Name", "CreateDate", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

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
                name: "IX_Users_Id_Email_CreateDate_IsDeleted",
                table: "Users",
                columns: new[] { "Id", "Email", "CreateDate", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogHashTag");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
