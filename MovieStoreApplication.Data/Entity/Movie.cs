using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    [Table("Movies")]
    public class Movie : BaseEntity<int>
    {
      
        [MaxLength(100)]
        public string Title { get; set; }
        public int Year { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
        public int DirectorId { get; set; }

        public List<Actor> Actors { get; set; }
        public int ActorId { get; set; }
        public double Price { get; set; }

    }

    
}
