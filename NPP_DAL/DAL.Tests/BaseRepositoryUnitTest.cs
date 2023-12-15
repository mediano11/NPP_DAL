using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestEmployeeRepository
        : BaseRepository<Employee>
    {
        public TestEmployeeRepository(DbContext context)
            : base(context)
        {

        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputEmployeeInstance_CalledAddMethodOfDBSetWithEmployeeInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<NPPContext>().Options;
            var mockContext = new Mock<NPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Employee>>();
            mockContext
                .Setup(context =>
                    context.Set<Employee>(
                        ))
                .Returns(mockDbSet.Object);

            var repository = new TestEmployeeRepository(mockContext.Object);

            Employee expectedEmployee = new Mock<Employee>().Object;

            //Act
            repository.Create(expectedEmployee);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedEmployee
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<NPPContext>()
                .Options;
            var mockContext = new Mock<NPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Employee>>();
            mockContext
                .Setup(context =>
                    context.Set<Employee>(
                        ))
                .Returns(mockDbSet.Object);

            var repository = new TestEmployeeRepository(mockContext.Object);

            Employee expectedEmployee = new Employee() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEmployee.Id)).Returns(expectedEmployee);

            //Act
            repository.Delete(expectedEmployee.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedEmployee.Id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedEmployee
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<NPPContext>()
                .Options;
            var mockContext = new Mock<NPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Employee>>();
            mockContext
                .Setup(context =>
                    context.Set<Employee>(
                        ))
                .Returns(mockDbSet.Object);

            Employee expectedEmployee = new Employee() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEmployee.Id))
                    .Returns(expectedEmployee);
            var repository = new TestEmployeeRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedEmployee.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedEmployee.Id
                    ), Times.Once());
            Assert.Equal(expectedEmployee, actualStreet);
        }
    }
}
