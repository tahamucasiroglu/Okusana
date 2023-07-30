using Okusana.Abstract.Repository;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Contexts.PgContext;
using Okusana.Infrasructure.Repository.Base;


namespace Okusana.Infrasructure.Repository.EfCore
{
    public class EfBlogRepository : AbstractRepository<Blog, OkusanaPgContext>, IBlogRepository
    {
        public EfBlogRepository(OkusanaPgContext context) : base(context) { }
    }
}
