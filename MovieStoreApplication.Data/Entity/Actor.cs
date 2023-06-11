using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    [Table("Actors")]
    public class Actor : BaseEntity<int>
    {
       
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname{ get; set; }
        public List<Movie> PlayedMovies{ get; set; }
        public GenderType? GenderType { get; set; }
    }

    public enum GenderType : byte
    {
        Male = 1, Female
    }
}
