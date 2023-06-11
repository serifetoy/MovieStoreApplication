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
        bool Add(Customer customer);
        Customer Update(int id, Customer customer);
        bool Delete(int id);

    }
}
