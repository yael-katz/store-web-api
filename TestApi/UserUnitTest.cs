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
        //private readonly Mock<Shop214957326Context> _mockContext;
        //private readonly Mock<DbSet<User>> _mockDbSet;

        //public UserUnitTest()
        //{
        //    _mockContext = new Mock<Shop214957326Context>();
        //    _mockDbSet = new Mock<DbSet<User>>();

        //    Setup the DbSet mock
        //    _mockContext.Setup(m => m.Users).Returns(_mockDbSet.Object);
        //}

       /* [Fact]
        public async Task Register_Should_Add_User_To_Database()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Test", LastName = "User", Email = "test.user@example.com", Password = "SecurePassword123" };

            _mockDbSet.Setup(m => m.AddAsync(It.IsAny<User>(), default))
                      .ReturnsAsync((Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User>)null);

            var repository = new UserRepository(_mockContext.Object);

            // Act
            var result = await repository.Register(user);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(user, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
            Assert.Equal(user, result);
        }
*/
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
  
