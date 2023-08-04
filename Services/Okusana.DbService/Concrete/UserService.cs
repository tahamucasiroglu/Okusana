using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.DTOs.Concrete.User;
using Okusana.Entities.Concrete;
using Okusana.Extensions;
using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Okusana.Constants.DbSettings.User;

namespace Okusana.DbService.Concrete
{
    public class UserService : AbstractService<User, GetUserDTO, AddUserDTO, UpdateUserDTO>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IActionResult GetByEmail(string Email)
        {
            IReturnModel<User> result = repository.Get(e => e.Email == Email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<User> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IActionResult GetByIdentity(string Identity)
        {
            IReturnModel<User> result = repository.Get(e => e.IdentityNumber == Identity);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IActionResult GetsByBirthdate(DateTime Birthdate)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.BirthDate.IsSameCalenderDate(Birthdate));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IActionResult GetsByName(string Name)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IActionResult GetsByStatus(string Status)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.Status.ToLower().Contains(Status.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetByEmailAsync(string Email)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.Email == Email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetByIdentityAsync(string Identity)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.IdentityNumber == Identity);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetsByBirthdateAsync(DateTime Birthdate)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.BirthDate.IsSameCalenderDate(Birthdate));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetsByNameAsync(string Name)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IActionResult> GetsByStatusAsync(string Status)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.Status.ToLower().Contains(Status.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }
    }
}
