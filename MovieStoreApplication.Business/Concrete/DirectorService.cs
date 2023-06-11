using AutoMapper;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Concrete
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;

        private readonly IMapper _mapper;

        public DirectorService(IMapper mapper, IDirectorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResult Add(DirectorDto directorDto)
        {
            var response = _repository.Add(_mapper.Map<Director>(directorDto));
            return response ? ServiceResult.Success() : ServiceResult.Failed(" Director Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }


        public List<DirectorDto> Search(string name, string surname)
        {
            var directors = _repository.Search(name, surname);
            return _mapper.Map<List<DirectorDto>>(directors);
        }

        public ServiceResult<DirectorDto> Update(int id, DirectorDto directorDto)
        {
            var m = _repository.Update(id, _mapper.Map<Director>(directorDto));

            if (m is null)
            {
                return ServiceResult<DirectorDto>.Failed(null, "Director Not Found", 404);
            }

            return ServiceResult<DirectorDto>.Success(_mapper.Map<DirectorDto>(m));
        }
    }
}
