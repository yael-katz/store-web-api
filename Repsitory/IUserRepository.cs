using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
        Task<User> Update(User user);
        Task<User> GetUserById(int userId);

    }
}