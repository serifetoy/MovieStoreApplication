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
        bool Add(Actor actor);
        Actor GetById(int id);
        Actor Update(int id, Actor actor);
        bool Delete(int id);
        List<Actor> Search(string name, string surname);


    }
}
