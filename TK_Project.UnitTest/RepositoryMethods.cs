using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories.User;
using TK_Project.UnitTest.Models;

namespace TK_Project.UnitTest
{
    public class RepositoryMethods
    {

        [Fact]
        public void ReadRepository_DataIsNull_WhenToList()
        {
            // Arrange
            var fakeContext = new Mock<IDbContext>();
            fakeContext.Setup(x => x.Data).Returns(new List<Domain.Entities.User>());
            var data = fakeContext.Object.Data.ToList();
            bool result = false;

            // Act
            if(data != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            // Assert
            Assert.True(result);
        }


        [Fact]
        public async void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange
            bool result = false;
            var readUser = new Mock<IUserReadRepository>();
            var data = await readUser.Object.GetByIdAsync(1);
            // Act
            if(data != null )
            {
                result = true;
            }
            else
            {
                result = false;
            }
            // Assert
            Assert.True(result);
        }
    }
}
