using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}