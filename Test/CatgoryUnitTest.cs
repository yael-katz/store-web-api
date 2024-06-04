using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repository;
using Xunit;

namespace UnitTests
{
    public class CategoryUnitTests
    {
        [Fact]
        public async Task Get_Should_Return_List_Of_Categories()
        {
            var mockContext = new Mock<Shop214957326Context>();
            var mockDbSet = new Mock<DbSet<Category>>();

            var categories = new List<Category>
        {
            new Category { CategoryId = 1, CategotyName = "Category 1" },
            new Category { CategoryId = 2, CategotyName = "Category 2" }
        }.AsQueryable();

            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            mockDbSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            mockDbSet.Setup(m => m.ToListAsync(default)).ReturnsAsync(categories.ToList());

            mockContext.Setup(c => c.Categories).Returns(mockDbSet.Object);
            var repository = new CategoryRepository(mockContext.Object);

            var result = await repository.Get();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Category 1", result[0].CategotyName);
            Assert.Equal("Category 2", result[1].CategotyName);
        }
    }
}