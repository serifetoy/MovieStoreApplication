using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface IGenreRepository
    {
        bool Add(Genre genre);
        Genre Update(int id, Genre genre);
        List<Genre> Search(string name);
        bool Delete(int id);
    }
}
