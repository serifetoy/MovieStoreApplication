using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface IActorService
    {
        ServiceResult Add(CreateActorDto actorDto);
        ServiceResult<ActorDto> GetById(int id);
        ServiceResult<ActorDto> Update(int id, ActorDto actorDto);
        ServiceResult Delete(int id);
        List<ActorDto> Search(string name, string surname, string sort ="asc");

    }
}
