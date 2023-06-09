using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface IMovieService
    {
        void Add(CreateMovieDto createMovie);
        GetMovieDto GetById(int id);
        List<GetMovieDto> GetAll(int page, int pageSize);
        ServiceResult<GetMovieDto> Update(int id, UpdateMovieDto updateMovie);
        List<GetMovieDto> Search(string name, int? directorId, int? actorId, int? price);
        void Delete(int id);
    }
}
