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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MovieContext _context;
        public CustomerRepository(MovieContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();
        }
        public void Update(int id, Customer customer)
        {
            var p = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (p is null) 
                throw new InvalidOperationException("Customer is not found");

            p.Name = customer.Name;
            p.Surname = customer.Surname;
            p.FavoriteMovies = customer.FavoriteMovies;
            p.Orders = customer.Orders;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new InvalidOperationException("Customer is Not Found");

            _context.Customers.Remove(p);

            _context.SaveChanges();
        }
    }
}
