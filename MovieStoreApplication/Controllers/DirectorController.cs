using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.DirectorDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using System.Collections.Generic;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class DirectorController : Controller
    {
        private readonly IDirectorService _service;
       
        public DirectorController(IDirectorService service)
        {
            
            _service = service;
        }

        [HttpGet("search")]
        public IActionResult Search(string name, string surname)
        {
            var response = _service.Search(name, surname);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDirectorDto directorDto)
        {
            var response = _service.Add(directorDto);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DirectorDto directorDto)
        {
            var response = _service.Update(id, directorDto);

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
