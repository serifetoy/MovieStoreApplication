using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.Concrete;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.CustomerDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using MovieStoreApplication.Mapping;
using Xunit;

namespace MovieStoreApplication.Tests
{
    public class CustomerServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _repositoryMock;
        private readonly Mock<ILogger<CustomerService>> _loggerMock;
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfileClass>();
            }).CreateMapper();

            _repositoryMock = new Mock<ICustomerRepository>();
            _loggerMock = new Mock<ILogger<CustomerService>>();
            _customerService = new CustomerService(_mapper, _repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void Add_ValidCustomerDto_ReturnsSuccessResult()
        {
            // Arrange
            var customerDto = new CreateCustomerDto
            {
                // Set necessary properties for the customerDto
            };

            _repositoryMock.Setup(mock => mock.Add(It.IsAny<Customer>())).Returns(true);

            // Act
            var result = _customerService.Add(customerDto);

            // Assert
            Assert.True(result.Succeed);
        }
   

        [Fact]
        public void Delete_ExistingId_ReturnsSuccessResult()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(mock => mock.Delete(id)).Returns(true);

            // Act
            var result = _customerService.Delete(id);

            // Assert
            Assert.True(result.Succeed);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(mock => mock.Delete(id)).Returns(false);

            // Act
            var result = _customerService.Delete(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

        [Fact]
        public void Update_ExistingIdAndValidCustomerDto_ReturnsSuccessResultWithUpdatedCustomerDto()
        {
            // Arrange
            var id = 1;
            var customerDto = new CustomerDto
            {
                // Set necessary properties for the customerDto
            };
            var updatedCustomer = new Customer
            {
                // Set necessary properties for the updated customer entity
            };

            _repositoryMock.Setup(mock => mock.Update(id, It.IsAny<Customer>())).Returns(updatedCustomer);

            // Act
            var result = _customerService.Update(id, customerDto);

            // Assert
            Assert.True(result.Succeed);
            
        }

      
    }
}
