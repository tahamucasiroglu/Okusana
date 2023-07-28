
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.User;

namespace Okusana.Abstract.Service
{
    public interface IUserService : IService<GetUserDTO, AddUserDTO, UpdateUserDTO>
    {
    }
}
