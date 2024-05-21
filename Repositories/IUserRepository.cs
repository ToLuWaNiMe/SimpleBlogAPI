using SimpleBlogAPI.Models;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
    }
}
