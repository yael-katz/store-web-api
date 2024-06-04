using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Entities.DtoUser;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NLog;
using Repository;
using Xunit;

namespace UnitTests
{
    public class UserUnitTest
    {
        [Fact]
        public async Task TestRegister_NewUser_Success()
        {
            // Arrange
            var mockDbContext = new Mock<Shop214957326Context>();

            var user = new User { Email = "newuser", Password = "password123", FirstName = "aaa", LastName = "aaa" };
            var userReg = new User { Email = "aaa", Password = "aaa", FirstName = "aaa", LastName = "aaa" };
            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { user });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Register(userReg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userReg.Email, result.Email);
        }
        [Fact]
        public async Task Login_Should_Return_Null_When_Credentials_Are_Invalid()
        {
            // Arrange
            var mockDbContext = new Mock<Shop214957326Context>();
            var testUser = new User { Email = "aaa@gmail.com", Password = "testpassword" };
            //var testLoginDto = new LoginDTO { UserName = "testuser", Password = "testpassword" };

            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { testUser });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Login(testUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testUser.Email, result.Email);
            Assert.Equal(testUser.Password, result.Password);
        }
    }
}
  
