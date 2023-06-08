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
        void Add(Order order);
        Order GetById(int id);
        List<Order> GetAll();
        void Update(int id, Order order);
        void Delete(int id);
    }
}
