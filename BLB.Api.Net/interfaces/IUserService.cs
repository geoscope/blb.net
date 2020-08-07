using System.Collections.Generic;
using BLB.Api.Net.Models;
using BLB.Domain.Net.Models;

namespace BLB.Api.Net.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(long id);
    }
}
