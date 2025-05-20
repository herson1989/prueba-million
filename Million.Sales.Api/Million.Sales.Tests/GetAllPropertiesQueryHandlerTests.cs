using Million.Sales.Application.Property.GetAll;
using Million.Sales.Domain.Entities;
using Million.Sales.Domain.Interfaces;
using Moq;

namespace Million.Sales.Tests
{
    [TestClass]
    public class GetAllPropertiesQueryHandlerTests
    {
        private Mock<IGetAllPropertiesUseCase> _mockUseCase;
        private GetAllPropertiesQueryHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _mockUseCase = new Mock<IGetAllPropertiesUseCase>();
            _handler = new GetAllPropertiesQueryHandler(_mockUseCase.Object);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnPropertiesSuccessfully()
        {
            // Arrange
            string expectedMessage = "Properties retrieved successfully.";
            var properties = new List<Property>
            {
                new() { Id = "abcd123456789", Name = "Casa primavera", Address = "Cra 45 # 44 - 77", Price = 100000, IdOwner = "owner123" }
            };

            var query = new GetAllPropertiesQuery();

            // Act
            _mockUseCase.Setup(x => x.Execute()).ReturnsAsync(properties);
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.IsNotNull(result.Properties);
            Assert.AreEqual(1, result.Properties.Count);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnEmptyList()
        {
            // Arrange
            string expectedMessage = "No properties found.";
            var query = new GetAllPropertiesQuery();

            // Act
            _mockUseCase.Setup(x => x.Execute()).ReturnsAsync(new List<Property>());
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.IsNotNull(result.Properties);
            Assert.AreEqual(0, result.Properties.Count);
        }


        [TestMethod]
        public async Task Handle_ShouldHandleNullList()
        {
            // Arrange
            string expectedMessage = "No properties found.";
            var query = new GetAllPropertiesQuery();

            // Act
            _mockUseCase.Setup(x => x.Execute()).ReturnsAsync((List<Property>?)null);
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.IsNotNull(result.Properties);
            Assert.AreEqual(0, result.Properties.Count);
        }
    }
}
