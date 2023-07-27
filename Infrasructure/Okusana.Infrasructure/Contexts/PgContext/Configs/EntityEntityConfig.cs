using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okusana.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Infrasructure.Contexts.PgContext.Configs
{
    public class EntityEntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> entity)
        {
            //entity.ToTable(nameof(OkusanaPgContext.Entities));
            entity.HasKey(e => e.Id);
            entity.UseTpcMappingStrategy();
            entity.HasQueryFilter(e => !e.IsDeleted);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("NOW()");
            //builder.HasIndex(e => new { e.IsDeleted, e.CreateDate });
        }
    }
}
