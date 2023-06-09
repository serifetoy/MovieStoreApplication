using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.MovieDTOs
{
    public class UpdateMovieDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int DirectorId { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
