using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Concrete.Repositories
{
    public class MovieRepository :IMovieRepository
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public bool Add(Movie movie)
        {
            movie = _context.Movies.SingleOrDefault(x => x.Title == movie.Title);

            if (movie != null)
                throw new InvalidOperationException("Movie already exist");

            _context.Movies.Add(movie);

           var result = _context.SaveChanges(); 
           return result > 0;
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetAll(int page, int pageSize)
        {
            return _context.Movies.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public Movie Update(int id, Movie movie)
        {
            var p = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new InvalidOperationException("Movie is not found");

            p.Title= movie.Title;
            p.Year= movie.Year;
            p.GenreId = movie.GenreId;
            p.ActorId = movie.ActorId;
            p.DirectorId = movie.DirectorId;
            p.Price = movie.Price;

            _context.SaveChanges();
            return p;
        }
        public List<Movie> Search(string title, int? directorId, int? actorId, int? price, string sort = "asc" )//title
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
                query.Where(x => x.Title.Contains(title));

            if (directorId.HasValue)
                query.Where(x => x.DirectorId == directorId);

            if (actorId.HasValue)
                query.Where(x => x.ActorId == actorId);

            if (price.HasValue)
                query.Where(x => x.Price > price);

            if (sort == "desc")
                query.OrderByDescending(x => x.Title);

            if (sort == "asc")
                query.OrderBy(x => x.Title);

            return query.ToList();
        }


        public bool Delete(int id)
        {
 
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) 
                return false;

            _context.Movies.Remove(movie);

            var result =_context.SaveChanges();

            return result > 0;
        }


    }
}
