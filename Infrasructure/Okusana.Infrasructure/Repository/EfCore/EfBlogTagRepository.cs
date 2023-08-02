using Okusana.Abstract.Repository;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Contexts.PgContext;
using Okusana.Infrasructure.Repository.Base;
using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Infrasructure.Repository.EfCore
{
    public class EfBlogTagRepository : AbstractRepository<BlogTag, OkusanaPgContext>, IBlogTagRepository
    {
        public EfBlogTagRepository(OkusanaPgContext context) : base(context) { }

    }
}
