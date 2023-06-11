using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Data.Entity
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
