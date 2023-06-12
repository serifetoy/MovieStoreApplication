using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using System.Collections.Generic;
using System;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using Azure;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ActorController : Controller
    {
        private readonly IActorService _service;
        private readonly IMapper _mapper;
        public ActorController(IMapper mapper, IActorService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] int id)//FromQuery
        {
            var actor = _service.GetById(id);

            if (actor is null)
            {
                return NotFound(actor.ErrorMessage);
            }

            return Ok(_mapper.Map<ActorDto>(actor));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActorDto actorDto)
        {
            var response = _service.Add(actorDto);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ActorDto actorDto)
        {
            var result = _service.Update(id, actorDto);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

    }
}
