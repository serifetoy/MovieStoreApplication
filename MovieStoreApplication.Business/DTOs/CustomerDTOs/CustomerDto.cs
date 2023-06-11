using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.CustomerDTOs
{
    public class CustomerDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        public List<Movie> FavoriteMovies { get; set; } //emin değilim nnull'a eşitlemeli miyim
        public List<Order> Orders { get; set; } //not sure same problem
    }
}
