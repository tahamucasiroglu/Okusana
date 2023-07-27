using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Okusana.Infrasructure.Extensions
{
    static public class ModelBuilderExtension
    {
        static public ModelBuilder UseTurkishSqlServer(this ModelBuilder builder) => builder.UseCollation("Turkish_CS_AS");
        static public ModelBuilder UseTurkishPostgreSql(this ModelBuilder builder) => builder.UseCollation("Turkish_Turkey.1254");
        static public ModelBuilder GetAllConfigsAuto(this ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
