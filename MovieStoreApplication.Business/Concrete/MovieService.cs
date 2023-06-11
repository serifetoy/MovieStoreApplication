using AutoMapper;
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

        private readonly IMapper _mapper;

        public MovieService(IMapper mapper, IMovieRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResult Add(CreateMovieDto movieDto)//emin olamadım
        {
            var response = _repository.Add(_mapper.Map<Movie>(movieDto));
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return response ? ServiceResult.Success(): ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<List<GetMovieDto>> GetAll(int page, int pageSize)
        {
            var movies = _repository.GetAll(page, pageSize);

            if (movies is null)
            {
                return ServiceResult<List<GetMovieDto>>.Failed(null, "Not Found", 404);

            }
            return ServiceResult<List<GetMovieDto>>.Success(_mapper.Map<List<GetMovieDto>>(movies));

        }

        public ServiceResult<GetMovieDto> GetById(int id)
        {
            var response = _mapper.Map<GetMovieDto>(_repository.GetById(id));

            if (response == null) 
            {
                return ServiceResult<GetMovieDto>.Failed(null,"Not Found", 404);
            }

            return ServiceResult<GetMovieDto>.Success(response);
        }

        public List<GetMovieDto> Search(string name, int? directorId, int? actorId, int? price)//emin değilim
        {
            var movies = _repository.Search(name, directorId, actorId, price);
            return _mapper.Map<List<GetMovieDto>>(movies);

        }

        public ServiceResult<GetMovieDto> Update(int id, UpdateMovieDto movie) 
        {
            var mov = _repository.GetById(id);

            if (mov is null)
            {
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            var m = _repository.Update(id, _mapper.Map<Movie>(movie));

            if (m is null)
            {
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<GetMovieDto>.Success(_mapper.Map<GetMovieDto>(m));
        }
    }
}
