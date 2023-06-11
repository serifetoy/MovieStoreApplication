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
    public class Genre : BaseEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }//emin değilim
    }
}
