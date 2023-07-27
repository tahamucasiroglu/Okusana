using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Entities.Base;
using Okusana.Entities.Concrete;
using Okusana.Extensions;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasBaseType(typeof(Entity));//test et (dev not: burada da oluyor galiba direk genel configde use tcp ile de oluyor bakalım.)
            //entity.ToTable(nameof(OkusanaPgContext.Users));
            //entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Id, e.Email, e.CreateDate, e.IsDeleted });
            entity.Ignore(e => e.FullName);
            entity.Ignore(e => e.Age);
            //entity.HasQueryFilter(e => !e.IsDeleted);
            //entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired(true)
                .HasComment("Üyelerin isimleri");

            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired(true)
                .HasComment("Üyelerin soy isimleri");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired(true)
                .HasComment("Üyelerin mail adresleri");

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsRequired(false)
                .IsUnicode(false)
                .HasConversion( //denenecek burası deneysel
                phone => phone,
                phone => phone.IsPhoneNumber()?phone:null) //burası telefon numarası kontrolü hatalı gelebildi ise buraya kadar null ekler bozuk veri kayıdı engellemek için bir nevi planda burası business içinde geçerli olacak
                .HasComment("Üyelerin telefon numaraları");

            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(11)
                .IsRequired(false)
                .IsUnicode(false)
                .HasConversion( //denenecek burası deneysel
                phone => phone,
                phone => phone.IsIdentityNumber() ? phone : null)
                .HasComment("Üyelerin kimlik nuamraları");

            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .IsRequired(true)//normalde datetime ama saat olayı olmayaccak date o yüzden burç bakmıyoz sonuçta
                .HasComment("Üyelerin doğum tarihleri");

            entity.Property(e => e.Gender)
                .HasColumnType("boolean")
                .IsRequired(false)
                .HasComment("Üyelerin cinsiyetleri false erkek true kadın null belirtmek istemiyorum");

            entity.Property(e => e.Password)
                .IsRequired(true)
                .HasMaxLength(64) //SHA 256
                .IsUnicode(false)//altına conversion ile 64 karakter kontrolü eklerim ama gereksiz sha 256 değilse buradan hata fırlatmam yok diye biliyorum olsa eklerdim bunu dluent kısmına ekleriz artık burada yine tüm kontroller eklensin.
                .HasComment("Üyelerin şifreleri sha 256 alınacak");
            //.HasComputedColumnSql("CASE WHEN LEN(Password) = 64 THEN Password ELSE NULL END"); //sonradan burada şöyle şeyler dene

            entity.Property(e => e.Status)
                .HasMaxLength(10)// admin editor member ananim 10 karakter yetiyor. gidipte buraya lorem*1000 ekelyerek db yi ağlatmasın
                .IsRequired(true)
                .IsUnicode(false)
                .HasComment("Üyelerin rütbeleri");










        }
    }
}
