using Okusana.Abstract.Repository;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Contexts.PgContext;
using Okusana.Infrasructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Infrasructure.Repository.EfCore
{
    public class EfBlogTagRepository : AbstractRepositoryCore<BlogTag, OkusanaPgContext>, IBlogTagRepository
    {
        public EfBlogTagRepository(OkusanaPgContext context) : base(context) { }
    }
}
