
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Request;
using Okusana.DTOs.Concrete.User;

namespace Okusana.Abstract.Service
{
    public interface IUserService : IService<GetUserDTO, AddUserDTO, UpdateUserDTO>
    {
        public IActionResult GetById(Guid Id);
        public IActionResult GetsByName(string Name);
        public IActionResult GetByEmail(string Email);
        public IActionResult GetByIdentity(string Identity);
        public IActionResult GetsByBirthdate(DateTime Birthdate);
        public IActionResult GetsByStatus(string Status);


        public Task<IActionResult> GetByIdAsync(Guid Id);
        public Task<IActionResult> GetsByNameAsync(string Name);
        public Task<IActionResult> GetByEmailAsync(string Email);
        public Task<IActionResult> GetByIdentityAsync(string Identity);
        public Task<IActionResult> GetsByBirthdateAsync(DateTime Birthdate);
        public Task<IActionResult> GetsByStatusAsync(string Status);
        public Task<IActionResult> LoginAsync(string Email, string Password);
        public Task<IActionResult> LogoutAsync();
    }
}
