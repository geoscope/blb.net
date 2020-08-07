
namespace BLB.Shared.Net.Interfaces
{
    public interface ISecurityHelper
    {
        string HashPassword(string password, string systemSalt, string userSalt);
    }
}
