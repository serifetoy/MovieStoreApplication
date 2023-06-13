using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.DirectorDTOs
{
    public class CreateDirectorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
