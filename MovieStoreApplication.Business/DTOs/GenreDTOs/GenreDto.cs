using MovieStoreApplication.Data.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.GenreDTOs
{
    public class GenreDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public List<Movie> Genres { get; set; }

    }
}
