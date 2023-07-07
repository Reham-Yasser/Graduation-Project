
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface ITokenService
    {
      Task<string> CreateToken(AppUser user , UserManager<AppUser> userManager);
    }
}
