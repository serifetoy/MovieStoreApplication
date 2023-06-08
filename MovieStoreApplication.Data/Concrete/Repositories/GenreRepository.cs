using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Concrete.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieContext _context;
        public GenreRepository(MovieContext context)
        {
            _context = context;
        }

        public void Add(Genre genre)
        {
            genre = _context.Genres.SingleOrDefault(x => x.Name == genre.Name);

            if (genre != null)
                throw new InvalidOperationException("Genre already exist");

            _context.Genres.Add(genre);

            _context.SaveChanges();
        }
        public void Update(int id, Genre genre)
        {
            var p = _context.Genres.FirstOrDefault(x => x.Id == id);

            if (p is null)
                throw new InvalidOperationException("Genre not found");

            p.Name = genre.Name;


            _context.SaveChanges();
        }
        public List<Genre> Search(string name)//look
        {
            //List<Movie>? playedMovies, parameter
            var query = _context.Genres.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            //if (playedMovies.)
            //    query.Where(x => x.PlayedMovies == playedMovies);

            return query.ToList();
        }

        public void Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);

            if (genre is null) throw new InvalidOperationException("Actor Not Found");

            _context.Genres.Remove(genre);

            _context.SaveChanges();
        }
    }
}
