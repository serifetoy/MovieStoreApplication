using MovieStoreApplication.Business.DTOs.GenreDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface IGenreService
    {
        ServiceResult Add(GenreDto genreDto);
        ServiceResult<GenreDto> Update(int id, GenreDto genreDto);
        List<GenreDto> Search(string name);
        ServiceResult Delete(int id);
    }
}
