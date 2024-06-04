using Entities;
using Repository;
using Zxcvbn;


namespace Service

{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> Register(User user)
        {
            return await userRepository.Register(user);
        }
        public async Task<User> Login(User user)
        {
            return await userRepository.Login(user);
        }
        public int CheckPasswordStrength(string password)
        {
            if (password == "")
            {
                return 0;
            }
            var res = Zxcvbn.Core.EvaluatePassword(password);
            return res.Score;
      
        }
        public async Task<User> Update(User user)
        {
            return await userRepository.Update(user);
        }
        public async Task<User> GetUserById(int userId)
        {
            return await userRepository.GetUserById(userId);
        }
    }
}
