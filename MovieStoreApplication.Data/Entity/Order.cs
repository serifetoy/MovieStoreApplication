using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie{ get; set; }    
        public int MovieId { get; set; }    
        public double Price{ get; set; }    
        public DateTime PurchaseDate{ get; set; }    
    }
}
