﻿using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;

namespace MovieStoreApplication.Controllers
{
    [Route("movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieController> _logger;//kullanmadım

        public MovieController(IMapper mapper, IMovieService service, ILogger<MovieController> logger)
        {
            _mapper = mapper;
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 10)
        {
            var movies = _service.GetAll(page, pageSize);
             
            return Ok(_mapper.Map<List<GetMovieDto>>(movies));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _service.GetById(id);
            
            if (movie is null)
            {
                return NotFound(movie.ErrorMessage); ;
            }

            return Ok(_mapper.Map<GetMovieDto>(movie));
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

