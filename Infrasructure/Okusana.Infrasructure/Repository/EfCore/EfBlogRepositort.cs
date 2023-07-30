using Okusana.Abstract.Repository;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Contexts.PgContext;
using Okusana.Infrasructure.Repository.Base;


namespace Okusana.Infrasructure.Repository.EfCore
{
    public class EfBlogRepositort : AbstractRepository<Blog, OkusanaPgContext>, IBlogRepository
    {
        public EfBlogRepositort(OkusanaPgContext context) : base(context) { }
    }
}
