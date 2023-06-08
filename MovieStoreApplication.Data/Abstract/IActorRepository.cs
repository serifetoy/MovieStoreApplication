using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface IActorRepository
    {
        void Add(Actor actor);
        void Update(int id, Actor actor);
        void Delete(int id);
        List<Actor> Search(string name, string surname);


    }
}
