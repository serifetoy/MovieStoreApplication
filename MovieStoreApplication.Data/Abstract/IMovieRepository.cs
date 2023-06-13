using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface IMovieRepository
    {
        bool Add(Movie movie); 
        Movie GetById(int id);
        List<Movie> GetAll(int page, int pageSize);
        Movie Update(int id, Movie movie);
        List<Movie> Search(string name, int? directorId, int? actorId, int? price, string sort = "asc");
        bool Delete(int id);
    }
}
