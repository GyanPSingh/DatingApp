using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Entities;

namespace WebAPI.interfaces
{
    public interface IUserRepository
    {
         void Update(AppUser appUser);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppUser>>GetUsersAsync();
         Task<AppUser> GetUsersByIdAsync(int id);
         Task<AppUser> GetUsersByUsernameAsync(string username);

         Task<IEnumerable<MembetDto>>GetMembersAsync();
         Task<MembetDto> GetMemberAsync(string username);
    }
}