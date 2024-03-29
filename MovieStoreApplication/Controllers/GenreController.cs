﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Business.DTOs.GenreDTOs;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController : Controller
    {
        private readonly IGenreService _service;
   
        public GenreController(IGenreService service)
        {
           
            _service = service;
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var response = _service.Search(name);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateGenreDto genreDto)
        {
            var response = _service.Add(genreDto);

            if (response.Succeed)
                return Created("/create", response);

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GenreDto genreDto)
        {
            var response = _service.Update(id, genreDto);

            if (response.Succeed)
                return Ok(response);

            return NotFound(response.ErrorMessage);

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
