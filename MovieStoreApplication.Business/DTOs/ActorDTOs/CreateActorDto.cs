using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.DTOs.ActorDTOs
{
    public class CreateActorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
