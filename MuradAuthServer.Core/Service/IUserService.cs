using MuradAuthServer.Core.DTOs;
using SharedLiblary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Core.Service
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<AppUserDto>> GetUserNameAsync(string userName);
    }
}
