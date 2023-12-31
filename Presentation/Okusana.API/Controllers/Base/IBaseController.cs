﻿using Microsoft.AspNetCore.Mvc;
using Okusana.DTOs.Abstract;

namespace Okusana.API.Controllers.Base
{
    public interface IBaseController
    {
        public Task<IActionResult> GetAll();
    }
    public interface IBaseController<TAdd> : IBaseController
        where TAdd : class, IAddDTO, new()
    {
        public Task<IActionResult> Add([FromBody] TAdd survey);
    }
    public interface IBaseController<TAdd, TUpdate> : IBaseController<TAdd>
        where TAdd : class, IAddDTO, new()
        where TUpdate : class, IUpdateDTO, new()
    {
        public Task<IActionResult> Update([FromBody] TUpdate survey);
    }
    public interface IBaseController<TAdd, TUpdate, TDelete> : IBaseController<TAdd, TUpdate>
        where TAdd : class, IAddDTO, new()
        where TUpdate : class, IUpdateDTO, new()
        where TDelete : class, IDeleteDTO, new()
    {
        public Task<IActionResult> Delete([FromBody] TDelete survey);
    }
}
