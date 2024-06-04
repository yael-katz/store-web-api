using Azure.Identity;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        Shop214957326Context shopContext;

        public UserRepository(Shop214957326Context shopContext)
        {
            this.shopContext = shopContext;
        }

        public async Task<User> Register(User user)
        {
            await shopContext.Users.AddAsync(user);
            await shopContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Login(User user)
        {
            User findUser = await shopContext.Users.FirstOrDefaultAsync(i => i.Email == user.Email && i.Password == user.Password);
            return findUser;
        }
        public async Task<User> Update(User user)
        {
            User findUser = await shopContext.Users.FindAsync(user.UserId);
            if (findUser != null)
            {
                findUser.FirstName = user.FirstName;
                findUser.LastName = user.LastName;
                findUser.Password = user.Password;
                findUser.Email = user.Email;

                await shopContext.SaveChangesAsync();
            }
            return findUser;
        }
        public async Task<User> GetUserById(int userId)
        {
            User findUser = await shopContext.Users.FindAsync(userId);
                return findUser;
        }


    }
}
