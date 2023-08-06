using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.User;
using Okusana.Entities.Concrete;
using Okusana.Extensions;
using Okusana.Returns.Abstract;
using Microsoft.Extensions.Configuration;
using Okusana.DTOs.Concrete.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace Okusana.DbService.Concrete
{
    public class UserService : AbstractService<User, GetUserDTO, AddUserDTO, UpdateUserDTO>, IUserService
    {

        public UserService(IUserRepository repository, IMapper mapper, IUserHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public IActionResult GetByEmail(string Email)
        {
            IReturnModel<User> result = repository.Get(e => e.Email == Email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<User> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public IActionResult GetByIdentity(string Identity)
        {
            IReturnModel<User> result = repository.Get(e => e.IdentityNumber == Identity);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public IActionResult GetsByBirthdate(DateTime Birthdate)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.BirthDate.IsSameCalenderDate(Birthdate));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public IActionResult GetsByName(string Name)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public IActionResult GetsByStatus(string Status)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(e => e.Status.ToLower().Contains(Status.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetByEmailAsync(string Email)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.Email == Email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetByIdentityAsync(string Identity)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.IdentityNumber == Identity);
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByBirthdateAsync(DateTime Birthdate)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.BirthDate.IsSameCalenderDate(Birthdate));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByNameAsync(string Name)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByStatusAsync(string Status)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(e => e.Status.ToLower().Contains(Status.ToLower()));
            return ConvertToReturn<GetUserDTO, User>(result, mapper, hateoas);
        }

        public async Task<IActionResult> LoginAsync(string Email, string Password)
        {
            IReturnModel<User> result = await repository.GetAsync(e => e.Email == Email);
            if (!result.Status || result.Data == null)
                return NotFoundReturn<GetUserDTO>("Mail adresi bulunamadı " + result.Message, result.Exception);
            else
            {
                if (result.Data.Password == Password)
                {
                    IReturnModel<GetTokenResponseDTO> token = await GenerateTokenWithSingIn(result.Data.Email, result.Data.Status);
                    return ConvertToReturn(result: token, hateoas: hateoas);
                }
                else
                {
                    return new BadRequestObjectResult("Hatalı parola");
                }
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            if(await Logout())
            {
                return ConvertToReturn(true,hateoas,null);
            }
            else
            {
                return ConvertToReturn(false, hateoas, null);
            }
        }
    }
}
