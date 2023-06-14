using AutoMapper;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public MovieService(IMapper mapper, IMovieRepository repository, ILogger<MovieService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public ServiceResult Add(CreateMovieDto movieDto)
        {
            var response = _repository.Add(_mapper.Map<Movie>(movieDto));
            
            if (!response)
                _logger.LogInformation("Movie not occured");

            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (!response)
                _logger.LogInformation("Movie not deleted");

            return response ? ServiceResult.Success(): ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<List<GetMovieDto>> GetAll(int page, int pageSize)
        {
            var movies = _repository.GetAll(page, pageSize);

            if (movies is null)
            {
                _logger.LogInformation("Movie not available");
                return ServiceResult<List<GetMovieDto>>.Failed(null, "Not Found", 404);

            }    

            return ServiceResult<List<GetMovieDto>>.Success(_mapper.Map<List<GetMovieDto>>(movies));

        }

        public ServiceResult<GetMovieDto> GetById(int id)
        {
            var response = _mapper.Map<GetMovieDto>(_repository.GetById(id));

            if (response == null) 
            {
                _logger.LogInformation("Movie not available");
                return ServiceResult<GetMovieDto>.Failed(null,"Movie Not Found", 404);
            }

            return ServiceResult<GetMovieDto>.Success(response);
        }

        public List<GetMovieDto> Search(string name, int? directorId, int? actorId, int? price, string sort ="asc")
        {
            var movies = _repository.Search(name, directorId, actorId, price, sort);

            if (movies is null)
                _logger.LogInformation("Movie not searchable");

            return _mapper.Map<List<GetMovieDto>>(movies);

        }

        public ServiceResult<GetMovieDto> Update(int id, UpdateMovieDto movie) 
        {
            var mov = _repository.GetById(id);

            if (mov is null)
            {
                _logger.LogInformation("Movie not available");
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            var m = _repository.Update(id, _mapper.Map<Movie>(movie));

            if (m is null)
            {
                _logger.LogInformation("Movie not updated");
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<GetMovieDto>.Success(_mapper.Map<GetMovieDto>(m));
        }
    }
}
