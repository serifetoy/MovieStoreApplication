﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
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
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ActorService(IMapper mapper, IActorRepository repository, ILogger<ActorService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public ServiceResult Add(CreateActorDto actorDto)
        {
            var response = _repository.Add(_mapper.Map<Actor>(actorDto));

            if (!response)
                _logger.LogInformation("Actor not occured");

            return response ? ServiceResult.Success() : ServiceResult.Failed(" Actor Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (!response)
                _logger.LogInformation("Actor not deleted");

            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<ActorDto> GetById(int id)
        {
            var response = _mapper.Map<ActorDto>(_repository.GetById(id));

            if (response == null)
            {
                _logger.LogInformation("Actor not available");
                return ServiceResult<ActorDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<ActorDto>.Success(response);
        }

        public List<ActorDto> Search(string name, string? surname, string sort = "asc")
        {
            var actors = _repository.Search(name, surname, sort);

            if (actors is null)
                _logger.LogInformation("Actor not searchable");

            return _mapper.Map<List<ActorDto>>(actors);
        }

        public ServiceResult<ActorDto> Update(int id, ActorDto actorDto)
        {
            var mov = _repository.GetById(id);

            if (mov is null)
            {
                _logger.LogInformation("Actor not available");
                return ServiceResult<ActorDto>.Failed(null, "Not Found", 404);
            }

            var m = _repository.Update(id,_mapper.Map<Actor>(actorDto));

            if (m is null)
            {
                _logger.LogInformation("Actor not updated");
                return ServiceResult<ActorDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<ActorDto>.Success(_mapper.Map<ActorDto>(m));
        }
    }
}
