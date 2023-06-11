using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.DirectorDTOs
{
    public class DirectorDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Surname { get; set; }
        [Required]
        public List<Movie> DirectedMovies { get; set; }
    }
}
