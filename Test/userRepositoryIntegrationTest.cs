/*using Azure.Identity;
using Entities;
using Entities.DtoUser;
using Repository;
using TestProject;

namespace Test
{
    public class UserRepositoryIntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly Shop214957326Context _dbContext;
        private readonly UserRepository userRepository;

        public UserRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            userRepository = new UserRepository(_dbContext);
        }

        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            var email = "test@example.com";
            var password = "password";
            var user = new User { Email = email, Password = password, FirstName = "ruth", LastName = "levi" } ;
            await _dbContext.Users.AddAsync(user);

            var result = await userRepository.Login(new User { Email = email, Password = password });

            Assert.NotNull(result);
         
        }
    }
}*/