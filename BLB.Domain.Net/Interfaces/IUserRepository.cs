using System.Threading.Tasks;
using BLB.Domain.Net.Models;

namespace BLB.Domain.Net.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserName(string username);

        Task<User> GetByUserNameAsync(string username);

        User AuthenticateUser(string username, string password);

        Task<User> AuthenticateUserAsync(string username, string password);
    }
}
