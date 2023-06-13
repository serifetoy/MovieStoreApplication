using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.Concrete;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Business.DTOs.OrderDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace MovieStoreApplication.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<OrderService>> _mockLogger;
        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<OrderService>>();
            _orderService = new OrderService(_mockMapper.Object, _mockOrderRepository.Object, _mockLogger.Object);
        }

    

        [Fact]
        public void Delete_NonExistingOrderId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _mockOrderRepository.Setup(r => r.Delete(id)).Returns(false);

            // Act
            var result = _orderService.Delete(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

        
        [Fact]
        public void GetAll_NoOrdersExist_ReturnsFailedResult()
        {
            // Arrange
            _mockOrderRepository.Setup(r => r.GetAll()).Returns((List<Order>)null);

            // Act
            var result = _orderService.GetAll();

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
            
        }

       

        [Fact]
        public void GetById_NonExistingOrderId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _mockOrderRepository.Setup(r => r.GetById(id)).Returns((Order)null);

            // Act
            var result = _orderService.GetById(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
            
        }

        [Fact]
        public void Update_NonExistingOrderId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _mockOrderRepository.Setup(r => r.GetById(id)).Returns((Order)null);

            // Act
            var result = _orderService.Update(id, new OrderDto());

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
            
        }
    }
}
