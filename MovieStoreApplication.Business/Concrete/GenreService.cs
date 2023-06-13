using AutoMapper;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Business.DTOs.GenreDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GenreService(IMapper mapper, IGenreRepository repository, ILogger<GenreService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public ServiceResult Add(CreateGenreDto genreDto)
        {
            var response = _repository.Add(_mapper.Map<Genre>(genreDto));

            if (!response)
                _logger.LogInformation("Genre not occured");

            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (!response)
                _logger.LogInformation("Genre not deleted");

            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public List<GenreDto> Search(string name, string sort ="asc")
        {
            var genres = _repository.Search(name);

            if (genres is null)
                _logger.LogInformation("Genre not searchable");

            return _mapper.Map<List<GenreDto>>(genres);
        }

        public ServiceResult<GenreDto> Update(int id, GenreDto genreDto)
        {
            var m = _repository.Update(id, _mapper.Map<Genre>(genreDto));

            if (m is null)
            {
                _logger.LogInformation("Genre not updated");
                return ServiceResult<GenreDto>.Failed(null, "Director Not Found", 404);
            }

            return ServiceResult<GenreDto>.Success(_mapper.Map<GenreDto>(m));
        }
    }
}
