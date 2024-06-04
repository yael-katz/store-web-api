using Entities;

namespace Service
{
    public interface IUserService
    {
        Task<User> Login(User user);
        Task<User> Register(User user);
        int CheckPasswordStrength(string password);
        Task<User> Update(User user);
        Task<User> GetUserById(int userId);

    }
}