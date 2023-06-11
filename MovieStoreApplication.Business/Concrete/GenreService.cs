using AutoMapper;
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

        private readonly IMapper _mapper;

        public GenreService(IMapper mapper, IGenreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResult Add(GenreDto genreDto)
        {
            var response = _repository.Add(_mapper.Map<Genre>(genreDto));
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public List<GenreDto> Search(string name)
        {
            var genres = _repository.Search(name);
            return _mapper.Map<List<GenreDto>>(genres);
        }

        public ServiceResult<GenreDto> Update(int id, GenreDto genreDto)
        {
            var m = _repository.Update(id, _mapper.Map<Genre>(genreDto));

            if (m is null)
            {
                return ServiceResult<GenreDto>.Failed(null, "Director Not Found", 404);
            }

            return ServiceResult<GenreDto>.Success(_mapper.Map<GenreDto>(m));
        }
    }
}
