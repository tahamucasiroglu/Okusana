using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class HashTagService : AbstractService<HashTag, GetHashTagDTO, AddHashTagDTO, UpdateHashTagDTO>
    {
        public HashTagService(IHashTagRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
