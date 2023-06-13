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

        public bool Add(Actor actor)
        {
            var existactor = _context.Actors.SingleOrDefault(x => x.Name == actor.Name && x.Surname == actor.Surname);

            if (existactor != null)
                throw new InvalidOperationException("Actor already exist");

            _context.Actors.Add(actor);

            var result = _context.SaveChanges();
            return result > 0;
        }
        public Actor Update(int id, Actor actor)
        {
            var p = _context.Actors.FirstOrDefault(x => x.Id == id);

            if (p is null)
                throw new InvalidOperationException("Actor not found");

            p.Name = actor.Name;
            p.Surname = actor.Surname;   

            _context.SaveChanges();
            return p;
        }
        public List<Actor> Search(string name, string surname, string sort = "asc" )
        {
            var query = _context.Actors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrWhiteSpace(surname))
                query.Where(x => x.Surname.Contains(surname));

            if (sort == "desc")
                query.OrderByDescending(x => x.Name);

            if (sort == "asc")
                query.OrderBy(x => x.Name);


            return query.ToList();
        }

        public bool Delete(int id)
        {
            var p = _context.Actors.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new InvalidOperationException("Actor Not Found");

            _context.Actors.Remove(p);

            var result = _context.SaveChanges();

            return result > 0;
        }

        public Actor GetById(int id)
        {
            return _context.Actors.FirstOrDefault(x => x.Id == id);
        }
    }
}
