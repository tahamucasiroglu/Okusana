﻿using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Category;
using Okusana.Entities.Concrete;
using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class CategoryService : AbstractService<Category, GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override IReturnModel<GetCategoryDTO> Add(AddCategoryDTO entity)
        {
            Console.WriteLine("asdasdasdas asdasdasdasasd");
            return base.Add(entity);
        }


    }
}
