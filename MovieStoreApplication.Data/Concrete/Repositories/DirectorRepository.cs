using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Concrete.Repositories
{
    public class DirectorRepository :IDirectorRepository
    {
        private readonly MovieContext _context;
        public DirectorRepository(MovieContext context)
        {
            _context = context;
        }

        public void Add(Director director)
        {
            director = _context.Directors.SingleOrDefault(x => x.Name == director.Name && x.Surname == director.Surname);

            if (director!= null)
                throw new InvalidOperationException("Director already exist");

            _context.Directors.Add(director);

            _context.SaveChanges();
        }
        public void Update(int id, Director director)
        {
            var p = _context.Directors.FirstOrDefault(x => x.Id == id);

            if (p is null)
                throw new InvalidOperationException("Director not found");

            p.Name = director.Name;
            p.Surname = director.Surname;

            _context.SaveChanges();
        }
        public List<Director> Search(string name, string surname)//look
        {
            //List<Movie>? playedMovies, parameter
            var query = _context.Directors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(surname))
                query.Where(x => x.Surname.Contains(surname));

            //if (playedMovies.)
            //    query.Where(x => x.PlayedMovies == playedMovies);


            return query.ToList();
        }

        public void Delete(int id)
        {
            var p = _context.Directors.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new InvalidOperationException("Director Not Found");

            _context.Directors.Remove(p);

            _context.SaveChanges();
        }

    }
}
