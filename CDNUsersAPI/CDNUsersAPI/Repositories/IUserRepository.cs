using CDNUsersAPI.Models;

namespace CDNUsersAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListUsers();

        Task<User> GetUserById(int id);

        Task AddUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(User user);
    }
}
