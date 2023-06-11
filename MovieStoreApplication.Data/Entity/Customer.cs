using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    [Table("Customers")]
    public class Customer : BaseEntity<int>
    {

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public List<Movie> FavoriteMovies { get; set; }
        public List<Order> Orders { get;set; }

    }
}
