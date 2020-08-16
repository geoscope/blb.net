using System.Collections.Generic;
using System.Threading.Tasks;
using BLB.Api.Net.Models;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);

        Task<User> GetByIdAsync(long id);
    }
}
