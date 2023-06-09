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

        public void Add(Movie movie)
        {
            movie = _context.Movies.SingleOrDefault(x => x.Title == movie.Title);

            if (movie != null)
                throw new InvalidOperationException("Movie already exist");

            _context.Movies.Add(movie);

            _context.SaveChanges();
        }

        public Movie GetById(int id)//look
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetAll(int page, int pageSize)//look
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
        public List<Movie> Search(string name, int? directorId, int? actorId, int? price )
        {
            var query = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Title.Contains(name));

            if (directorId.HasValue)
                query.Where(x => x.DirectorId == directorId);

            if (actorId.HasValue)
                query.Where(x => x.ActorId == actorId);

            if (price.HasValue)
                query.Where(x => x.Price > price);

            return query.ToList();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) 
                throw new InvalidOperationException("Movie not found");

            _context.Movies.Remove(movie);

            _context.SaveChanges();
        }


    }
}
