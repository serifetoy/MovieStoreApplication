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
        ServiceResult Add(CreateMovieDto createMovie);
        ServiceResult<GetMovieDto> GetById(int id);
        ServiceResult<List<GetMovieDto>> GetAll(int page, int pageSize);
        ServiceResult<GetMovieDto> Update(int id, UpdateMovieDto updateMovie);
        List<GetMovieDto> Search(string name, int? directorId, int? actorId, int? price);
        ServiceResult Delete(int id);
    }
}
