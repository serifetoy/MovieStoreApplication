using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(int id, Customer customer);
        void Delete(int id);

    }
}
