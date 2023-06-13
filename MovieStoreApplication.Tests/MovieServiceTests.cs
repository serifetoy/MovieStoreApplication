using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.Concrete;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System.Collections.Generic;
using Xunit;

namespace MovieStoreApplication.Tests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _repositoryMock;
        private readonly Mock<ILogger<MovieService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IMovieService _movieService;

        public MovieServiceTests()
        {
            _repositoryMock = new Mock<IMovieRepository>();
            _loggerMock = new Mock<ILogger<MovieService>>();
            _mapperMock = new Mock<IMapper>();
            _movieService = new MovieService(_mapperMock.Object, _repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void Add_ValidMovieDto_ReturnsSuccessResult()
        {
            // Arrange
            var movieDto = new CreateMovieDto();
            var movie = new Movie();
            _mapperMock.Setup(m => m.Map<Movie>(movieDto)).Returns(movie);
            _repositoryMock.Setup(r => r.Add(movie)).Returns(true);

            // Act
            var result = _movieService.Add(movieDto);

            // Assert
            Assert.True(result.Succeed);
            
        }

        [Fact]
        public void Add_InvalidMovieDto_ReturnsFailedResult()
        {
            // Arrange
            var movieDto = new CreateMovieDto();
            var movie = new Movie();
            _mapperMock.Setup(m => m.Map<Movie>(movieDto)).Returns(movie);
            _repositoryMock.Setup(r => r.Add(movie)).Returns(false);

            // Act
            var result = _movieService.Add(movieDto);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

        [Fact]
        public void Delete_ExistingMovieId_ReturnsSuccessResult()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(r => r.Delete(id)).Returns(true);

            // Act
            var result = _movieService.Delete(id);

            // Assert
            Assert.True(result.Succeed);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(0, result.ErrorCode);
        }

        [Fact]
        public void Delete_NonExistingMovieId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(r => r.Delete(id)).Returns(false);

            // Act
            var result = _movieService.Delete(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);


        }

        [Fact]
        public void GetAll_ValidPageAndPageSize_ReturnsSuccessResultWithMovieList()
        {
            // Arrange
            var page = 1;
            var pageSize = 10;
            var movies = new List<Movie>(); 
            _repositoryMock.Setup(r => r.GetAll(page, pageSize)).Returns(movies);
            _mapperMock.Setup(m => m.Map<List<GetMovieDto>>(movies)).Returns(new List<GetMovieDto>());

            // Act
            var result = _movieService.GetAll(page, pageSize);

            // Assert
            Assert.True(result.Succeed);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(0, result.ErrorCode);
            
        }

        [Fact]
        public void GetAll_InvalidPageAndPageSize_ReturnsFailedResult()
        {
            // Arrange
            var page = -1;
            var pageSize = 0;

            // Act
            var result = _movieService.GetAll(page, pageSize);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
            
        }

        [Fact]
        public void GetById_ExistingMovieId_ReturnsSuccessResultWithMovie()
        {
            // Arrange
            var id = 1;
            var movie = new Movie(); 
            _repositoryMock.Setup(r => r.GetById(id)).Returns(movie);
            _mapperMock.Setup(m => m.Map<GetMovieDto>(movie)).Returns(new GetMovieDto());

            // Act
            var result = _movieService.GetById(id);

            // Assert
            Assert.True(result.Succeed);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(0, result.ErrorCode);
            
        }

        [Fact]
        public void GetById_NonExistingMovieId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            _repositoryMock.Setup(r => r.GetById(id)).Returns((Movie)null);

            // Act
            var result = _movieService.GetById(id);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Movie Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
            
        }

        [Fact]
        public void Search_ValidParameters_ReturnsMovieList()
        {
            // Arrange
            var name = "Test";
            var directorId = 1;
            var actorId = 2;
            var price = 10;
            var sort = "asc";
            var movies = new List<Movie>(); 
            _repositoryMock.Setup(r => r.Search(name, directorId, actorId, price, sort)).Returns(movies);
            _mapperMock.Setup(m => m.Map<List<GetMovieDto>>(movies)).Returns(new List<GetMovieDto>());

            // Act
            var result = _movieService.Search(name, directorId, actorId, price, sort);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void Update_ExistingMovieIdAndValidMovie_ReturnsSuccessResultWithUpdatedMovie()
        {
            // Arrange
            var id = 1;
            var movie = new UpdateMovieDto(); 
            var existingMovie = new Movie(); 
            var updatedMovie = new Movie(); 
            _repositoryMock.Setup(r => r.GetById(id)).Returns(existingMovie);
            _repositoryMock.Setup(r => r.Update(id, It.IsAny<Movie>())).Returns(updatedMovie);
            _mapperMock.Setup(m => m.Map<GetMovieDto>(updatedMovie)).Returns(new GetMovieDto());

            // Act
            var result = _movieService.Update(id, movie);

            // Assert
            Assert.True(result.Succeed);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(0, result.ErrorCode);
            
        }

        [Fact]
        public void Update_NonExistingMovieId_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            var movie = new UpdateMovieDto(); 
            _repositoryMock.Setup(r => r.GetById(id)).Returns((Movie)null);

            // Act
            var result = _movieService.Update(id, movie);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }

        [Fact]
        public void Update_ExistingMovieIdAndInvalidMovie_ReturnsFailedResult()
        {
            // Arrange
            var id = 1;
            var movie = new UpdateMovieDto(); 
            var existingMovie = new Movie(); 
            _repositoryMock.Setup(r => r.GetById(id)).Returns(existingMovie);
            _repositoryMock.Setup(r => r.Update(id, It.IsAny<Movie>())).Returns((Movie)null);

            // Act
            var result = _movieService.Update(id, movie);

            // Assert
            Assert.False(result.Succeed);
            Assert.Equal("Not Found", result.ErrorMessage);
            Assert.Equal(404, result.ErrorCode);
        }



    }
}
