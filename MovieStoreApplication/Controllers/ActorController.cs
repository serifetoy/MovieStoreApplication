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
      
        public ActorController(IActorService service)
        {
            
            _service = service;
        }


        [HttpGet("{id}")]
        public IActionResult GetById( int id)
        {
            var actor = _service.GetById(id);

            if (actor is null)
            {
                return NotFound(actor.ErrorMessage);
            }

            return Ok(actor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateActorDto actorDto)
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
