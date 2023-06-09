using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.MovieDTOs
{
    public class GetMovieDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int ActorId { get; set; }
        public double Price { get; set; }
    }
}
