using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Abstract
{
    public interface IOrderRepository
    {
        bool Add(Order order);
        Order GetById(int id);
        List<Order> GetAll();
        Order Update(int id, Order order);
        bool Delete(int id);
    }
}
