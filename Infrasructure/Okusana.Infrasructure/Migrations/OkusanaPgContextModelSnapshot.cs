﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Okusana.Infrasructure.Contexts.PgContext;

#nullable disable

namespace Okusana.Infrasructure.Migrations
{
    [DbContext(typeof(OkusanaPgContext))]
    partial class OkusanaPgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Okusana")
                .UseCollation("Turkish_Turkey.1254")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Okusana.Entities.Base.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Blog", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("text")
                        .HasComment("blog gövdesi 3000 karakter sınırı var");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean")
                        .HasComment("yayınlanma durumunu verir");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("isteğe bağlı yayınlanma tarihi");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("character varying(150)")
                        .HasComment("Blog başlığı 150 karakter sınırı var");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserId");

                    b.HasIndex("Title", "IsPublished", "CreateDate", "IsDeleted");

                    b.ToTable("Blogs", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.BlogTag", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagId", "BlogId");

                    b.ToTable("BlogTags", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Category", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("character varying(150)")
                        .HasComment("category aciklamasi");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasComment("kategori adlari");

                    b.HasIndex("Name");

                    b.ToTable("Categories", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Comment", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("text")
                        .HasComment("kullanıcı yorum yazısı");

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean")
                        .HasComment("kullanıcı beğenme durumu");

                    b.Property<int?>("Rate")
                        .HasColumnType("integer")
                        .HasComment("kullanıcı puan değeri 5 üzerinden olur bir değişiklik olmazsa");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasIndex("BlogId");

                    b.HasIndex("UserId");

                    b.HasIndex("Rate", "IsLike", "CreateDate", "IsDeleted");

                    b.ToTable("Comments", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.HashTag", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasComment("etiket ismi");

                    b.HasIndex("Name", "CreateDate", "IsDeleted");

                    b.ToTable("HashTags", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.SubCategory", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("character varying(150)")
                        .HasComment("category aciklamasi");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasComment("SubCategory adlari");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name");

                    b.ToTable("SubCategories", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.User", b =>
                {
                    b.HasBaseType("Okusana.Entities.Base.Entity");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasComment("Üyelerin doğum tarihleri");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)")
                        .HasComment("Üyelerin mail adresleri");

                    b.Property<bool?>("Gender")
                        .HasColumnType("boolean")
                        .HasComment("Üyelerin cinsiyetleri false erkek true kadın null belirtmek istemiyorum");

                    b.Property<string>("IdentityNumber")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("character varying(11)")
                        .HasComment("Üyelerin kimlik nuamraları");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)")
                        .HasComment("Üyelerin isimleri");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)")
                        .HasComment("Üyelerin şifreleri sha 256 alınacak");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasComment("Üyelerin telefon numaraları");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasComment("Üyelerin rütbeleri");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("character varying(100)")
                        .HasComment("Üyelerin soy isimleri");

                    b.HasIndex("Id", "Email", "CreateDate", "IsDeleted");

                    b.ToTable("Users", "Okusana");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Blog", b =>
                {
                    b.HasOne("Okusana.Entities.Concrete.SubCategory", "SubCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Blog_SubCategories");

                    b.HasOne("Okusana.Entities.Concrete.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Blog_User");

                    b.Navigation("SubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.BlogTag", b =>
                {
                    b.HasOne("Okusana.Entities.Concrete.Blog", "Blog")
                        .WithMany("BlogTags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BlogTag_Blog");

                    b.HasOne("Okusana.Entities.Concrete.HashTag", "HashTag")
                        .WithMany("BlogTags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BlogTag_HashTag");

                    b.Navigation("Blog");

                    b.Navigation("HashTag");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("Okusana.Entities.Concrete.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_Blog");

                    b.HasOne("Okusana.Entities.Concrete.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_User");

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.SubCategory", b =>
                {
                    b.HasOne("Okusana.Entities.Concrete.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_SubCategory_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Blog", b =>
                {
                    b.Navigation("BlogTags");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.HashTag", b =>
                {
                    b.Navigation("BlogTags");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.SubCategory", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Okusana.Entities.Concrete.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
