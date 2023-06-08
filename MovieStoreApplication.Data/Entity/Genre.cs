using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    [Table("Genres")]
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Movie> Genres { get; set; }
    }
}
