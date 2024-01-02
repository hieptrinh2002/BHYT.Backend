using AutoMapper;
using BHYT.API.Controllers;
using BHYT.API.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BHYT.API.Tests
{
    public class InsurancePaymentControllerTests
    {
        private readonly Mock<BHYTDbContext> _mockContext;
        private readonly Mock<IMapper> _mockMapper;
        private readonly InsurancePaymentController _controller;

        public InsurancePaymentControllerTests()
        {
            var options = new DbContextOptionsBuilder<BHYTDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            _mockContext = new Mock<BHYTDbContext>(options);
            _mockMapper = new Mock<IMapper>();
            _controller = new InsurancePaymentController(_mockContext.Object,_mockMapper.Object);
        }

        [Fact]
        public async Task GetUserInsurancePayment_ReturnsNotFound_WhenNoPaymentsExist()
        {
            // Arrange
            var testId = 1;
            var data = new List<InsurancePayment>().AsQueryable();
            var mockSet = new Mock<DbSet<InsurancePayment>>();
            mockSet.As<IQueryable<InsurancePayment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<InsurancePayment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<InsurancePayment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<InsurancePayment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext.Setup(ctx => ctx.InsurancePayments).Returns(mockSet.Object);


            // Act
            var result = await _controller.GetUserInsurancePayment(testId);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }

        // Add more tests...
    }
}