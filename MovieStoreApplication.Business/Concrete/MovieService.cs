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

        public void Add(CreateMovieDto movieDto) //emin değilim
        {
            var movie= _mapper.Map<Movie>(movieDto);
            _repository.Add(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<GetMovieDto> GetAll(int page, int pageSize)
        {
            var movies = _repository.GetAll(page, pageSize);  
            return _mapper.Map<List<GetMovieDto>>(movies);

        }

        public GetMovieDto GetById(int id)
        {
            return _mapper.Map<GetMovieDto>(_repository.GetById(id));
        }

        public List<GetMovieDto> Search(string name, int? directorId, int? actorId, int? price)//emin değilim
        {
            var movies = _repository.Search(name, directorId, actorId, price);
            return _mapper.Map<List<GetMovieDto>>(movies);

        }

        public ServiceResult<GetMovieDto> Update(int id, UpdateMovieDto movie) 
        {
            var pr = _repository.GetById(id);

            if (pr is null)
            {
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            var p = _repository.Update(id, _mapper.Map<Movie>(movie));

            if (p is null)
            {
                return ServiceResult<GetMovieDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<GetMovieDto>.Success(_mapper.Map<GetMovieDto>(p));
        }
    }
}
