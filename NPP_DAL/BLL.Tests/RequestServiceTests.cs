using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class RequestServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new RequestService(nullUnitOfWork));
        }

        [Fact]
        public void GetRequests_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new SanatoriumManager(1, "name1", 1, "position1");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRequestService requestService = new RequestService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => requestService.GetRequests(0));
        }

        [Fact]
        public void GetRequests_RequestFromDAL_CorrectMappingToRequestDTO()
        {
            // Arrange
            User user = new Admin(1, "admin1", 1, "position1");
            SecurityContext.SetUser(user);
            var requestService = GetRequestService();

            // Act
            var actualRequstDto = requestService.GetRequests(0).First();
            // Assert
            Assert.True(
                actualRequstDto.Id == 1
                && actualRequstDto.Type.ToString().Equals(RequestType.Annual.ToString())
                && actualRequstDto.IsVoucher == true
                && actualRequstDto.Reason == "reason1"
                && actualRequstDto.DurationFrom == new DateTime(2023, 6, 1)
                && actualRequstDto.DurationTo == new DateTime(2023, 6, 15)
                ); ;
        }
        

        IRequestService GetRequestService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRequest = new Request() {
                Id = 1, Type = RequestType.Annual,
                IsVoucher = true,
                Reason = "reason1",
                DurationFrom = new DateTime(2023, 6, 1),
                DurationTo = new DateTime(2023, 6, 15),
                EmployeeId = 2 
            };
            var mockDbSet = new Mock<IRequestRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<Request, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<Request>() { expectedRequest }
                    );
            mockContext
                .Setup(context =>
                    context.Requests)
                .Returns(mockDbSet.Object);

            IRequestService requestService = new RequestService(mockContext.Object);

            return requestService;
        }
    }
}