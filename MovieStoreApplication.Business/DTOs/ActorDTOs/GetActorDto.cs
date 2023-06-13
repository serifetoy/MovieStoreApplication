using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.ActorDTOs
{
    public class GetActorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> PlayedMovies { get; set; }
    }
}
