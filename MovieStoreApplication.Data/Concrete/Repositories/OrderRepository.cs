using Microsoft.EntityFrameworkCore;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Concrete.Repositories
{
    public  class OrderRepository: IOrderRepository
    {
        private readonly MovieContext _context;
        public OrderRepository(MovieContext context)
        {
            _context = context;
        }
        public bool Add(Order order)
        {
            order = _context.Orders.SingleOrDefault(x => x.Customer.Id == order.CustomerId && x.Movie.Id == order.MovieId);

            if (order != null)
                throw new InvalidOperationException("Order already exist");

            _context.Orders.Add(order);

            var result = _context.SaveChanges();

            return result > 0;
        }

        public Order GetById(int id)
        {
            var order = _context.Orders.Include(x => x.Movie).Include(x => x.Customer).SingleOrDefault(x => x.Id == id);

            if (order is null)
                throw new InvalidOperationException("Order Not Found");

            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll()//not sure ??
        {
            var orderList = _context.Orders.Include(x => x.Movie).Include(x => x.Customer).OrderBy(x => x.Id).ToList<Order>();
            return orderList;
        }

        public Order Update(int id, Order order)
        {
            var item = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (item is null)
                throw new InvalidOperationException("Order not found");

            item.CustomerId = order.CustomerId != default ? order.CustomerId : item.CustomerId;
            item.MovieId = order.MovieId != default ? order.MovieId : item.MovieId;

            item.Customer = _context.Customers.SingleOrDefault(x => x.Id == order.CustomerId);
            item.Movie = _context.Movies.SingleOrDefault(x => x.Id == order.MovieId);


            _context.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order is null) throw new InvalidOperationException("Order Not Found");

            _context.Orders.Remove(order);

            var result = _context.SaveChanges();

            return result > 0;
        }




    }
}
