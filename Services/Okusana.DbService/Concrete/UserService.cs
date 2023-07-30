using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.User;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class UserService : AbstractService<User, GetUserDTO, AddUserDTO, UpdateUserDTO>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
