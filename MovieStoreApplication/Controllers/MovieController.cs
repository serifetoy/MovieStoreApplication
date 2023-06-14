using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        
        private readonly ILogger<MovieController> _logger;//kullanmadım

        public MovieController( IMovieService service, ILogger<MovieController> logger)
        {  
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 10)
        {
            return Ok(_service.GetAll(page, pageSize));

            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _service.GetById(id);
            
            if (movie is null)
            {
                return NotFound(movie.ErrorMessage); ;
            }
            
            return Ok(movie);

           
        }

        [HttpGet("search")]
        public IActionResult Search(string name, int? directorId, int? actorId, int? price)
        {
            var response = _service.Search(name, directorId, actorId, price);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create( [FromBody] CreateMovieDto movieDto)
        {
            var response = _service.Add(movieDto);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieDto movieDto)
        {
           var response = _service.Update(id, movieDto);
           
            if (response.Succeed)
                return Ok(response);

            return NotFound(response.ErrorMessage);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);

            if(response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

    }



}

