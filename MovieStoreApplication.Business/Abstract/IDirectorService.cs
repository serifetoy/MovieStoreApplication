using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface IDirectorService
    {
        ServiceResult Add(CreateDirectorDto directorDto);
        ServiceResult<DirectorDto> Update(int id, DirectorDto directorDto);
        List<DirectorDto> Search(string name, string surname, string sort= "asc");
        ServiceResult Delete(int id);

    }
}
