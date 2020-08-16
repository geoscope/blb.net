using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserNameAsync(string username);

        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
