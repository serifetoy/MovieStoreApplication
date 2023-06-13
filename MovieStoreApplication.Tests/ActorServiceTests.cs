using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.Concrete;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using MovieStoreApplication.Mapping;
using System.Collections.Generic;
using Xunit;

namespace MovieStoreApplication.Tests
{
    public class ActorServiceTests
    {
        private readonly Mock<IActorRepository> _mockRepository;
        private readonly Mock<ILogger<ActorService>> _mockLogger;
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;

        public ActorServiceTests()
        {
            _mockRepository = new Mock<IActorRepository>();
            _mockLogger = new Mock<ILogger<ActorService>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfileClass());
            });
            _mapper = mockMapper.CreateMapper();

            _actorService = new ActorService(_mapper, _mockRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public void Add_ValidActorDto_ReturnsSuccess()
        {
            // Arrange
            var actorDto = new CreateActorDto
            {

            };

            _mockRepository.Setup(r => r.Add(It.IsAny<Actor>())).Returns(true);

            // Act
            var result = _actorService.Add(actorDto);

            // Assert
            Assert.True(result.Succeed);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsSuccess()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(r => r.Delete(id)).Returns(true);

            // Act
            var result = _actorService.Delete(id);

            // Assert
            Assert.True(result.Succeed);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsFailed()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(r => r.Delete(id)).Returns(false);

            // Act
            var result = _actorService.Delete(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }


        [Fact]
        public void GetById_ExistingId_ReturnsActorDto()
        {
            // Arrange
            var id = 1;
            var actor = new Actor { Id = id, Name = "John", Surname = "Doe" };
            _mockRepository.Setup(r => r.GetById(id)).Returns(actor);

            // Act
            var result = _actorService.GetById(id);

            // Assert
            Assert.True(result.Succeed);

        }

        [Fact]
        public void GetById_NonExistingId_ReturnsFailed()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(r => r.GetById(id)).Returns((Actor)null);

            // Act
            var result = _actorService.GetById(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

        [Fact]
        public void Search_ValidParameters_ReturnsListOfActorDto()
        {
            // Arrange
            var name = "John";
            var surname = "Doe";
            var sort = "asc";
            var actors = new List<Actor>
    {
        new Actor { Id = 1, Name = "John", Surname = "Doe" },
        new Actor { Id = 2, Name = "Jane", Surname = "Smith" }
    };
            _mockRepository.Setup(r => r.Search(name, surname, sort)).Returns(actors);

            // Act
            var result = _actorService.Search(name, surname, sort);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(actors.Count, result.Count);
            
        }

        [Fact]
        public void Search_InvalidParameters_ReturnsEmptyList()
        {
            // Arrange
            var name = "John";
            var surname = "Doe";
            var sort = "asc";
            _mockRepository.Setup(r => r.Search(name, surname, sort)).Returns((List<Actor>)null);

            // Act
            var result = _actorService.Search(name, surname, sort);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Update_ExistingId_ReturnsUpdatedActorDto()
        {
            // Arrange
            var id = 1;
            var actorDto = new ActorDto { Name = "John", Surname = "Doe" };
            var existingActor = new Actor { Id = id, Name = "John", Surname = "Smith" };
            _mockRepository.Setup(r => r.GetById(id)).Returns(existingActor);
            _mockRepository.Setup(r => r.Update(id, It.IsAny<Actor>())).Returns(existingActor);

            // Act
            var result = _actorService.Update(id, actorDto);

            // Assert
            Assert.True(result.Succeed);
        }

        [Fact]
        public void Update_NonExistingId_ReturnsFailed()
        {
            // Arrange
            var id = 1;
            var actorDto = new ActorDto { Name = "John", Surname = "Doe" };
            _mockRepository.Setup(r => r.GetById(id)).Returns((Actor)null);

            // Act
            var result = _actorService.Update(id, actorDto);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

    }

}
