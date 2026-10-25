using GerenciaAssistenciaTecnica.Infrastructure.Data;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IUserRepository : IAsyncRepository<AppUser>
    {
        AppUser ValidadeUser(AppUser user);

        List<AppUserClaim> ListClaims(AppUser user);

        Task<bool> UserNameExistsAsync(string userName);
    }
}
