using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Concrete.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieContext _context;
        public ActorRepository(MovieContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            actor = _context.Actors.SingleOrDefault(x => x.Name == actor.Name && x.Surname == actor.Surname);

            if (actor != null)
                throw new InvalidOperationException("Actor already exist");

            _context.Actors.Add(actor);

            _context.SaveChanges();
        }
        public void Update(int id, Actor actor)
        {
            var p = _context.Actors.FirstOrDefault(x => x.Id == id);

            if (p is null)
                throw new InvalidOperationException("Actor not found");

            p.Name = actor.Name;
            p.Surname = actor.Surname;   

            _context.SaveChanges();
        }
        public List<Actor> Search(string name, string surname )
        {
            //List<Movie>? playedMovies, parameter
            var query = _context.Actors.AsQueryable();

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
            var p = _context.Actors.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new InvalidOperationException("Actor Not Found");

            _context.Actors.Remove(p);

            _context.SaveChanges();
        }



    }
}
