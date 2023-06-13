using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.OrderDTOs
{
    public class OrderDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
