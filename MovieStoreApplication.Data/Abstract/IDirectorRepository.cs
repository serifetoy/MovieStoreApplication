using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface IDirectorRepository
    {
        bool Add(Director director);
        Director Update(int id, Director director);
        List<Director> Search(string name, string surname, string sort = "asc");
        bool Delete(int id);

    }
}
