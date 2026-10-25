using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class UserRepository : EfRepository<AppUser>, IUserRepository
    {
        public UserRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public AppUser ValidadeUser(AppUser user)
        {
            return _dbContext.Users.Where(
                  u => u.UserName.ToLower() == user.UserName.ToLower()
                  && u.Password == user.Password).FirstOrDefault();
        }

        public List<AppUserClaim> ListClaims(AppUser user)
        {
            return _dbContext.Claims.Where(
                                 u => u.UserId == user.UserId).ToList();
        }

        public Task<bool> UserNameExistsAsync(string userName)
        {
            return _dbContext.Users.AnyAsync(
                user => user.UserName.ToLower() == userName.ToLower());
        }
    }
}
