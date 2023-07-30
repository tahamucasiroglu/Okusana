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
    public class EfSubCategoryRepository : AbstractRepository<SubCategory, OkusanaPgContext>, ISubCategoryRepository
    {
        public EfSubCategoryRepository(OkusanaPgContext context) : base(context) { }
    }
}
