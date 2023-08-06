using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Comment;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.Entities.Concrete;
using Okusana.Models.HateoasModel;
using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class HashTagService : AbstractService<HashTag, GetHashTagDTO, AddHashTagDTO, UpdateHashTagDTO>, IHashTagService
    {
        public HashTagService(IHashTagRepository repository, IMapper mapper, IHashTagHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<HashTag> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetHashTagDTO, HashTag>(result, mapper);
        }

        public IActionResult GetByName(string Name)
        {
            IReturnModel<HashTag> result = repository.Get(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetHashTagDTO, HashTag>(result, mapper);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<HashTag> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetHashTagDTO, HashTag>(result, mapper);
        }

        public async Task<IActionResult> GetByNameAsync(string Name)
        {
            IReturnModel<HashTag> result = await repository.GetAsync(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetHashTagDTO, HashTag>(result, mapper);
        }
    }
}
