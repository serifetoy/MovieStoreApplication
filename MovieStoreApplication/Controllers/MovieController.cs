using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public MovieController(IMapper mapper, IMovieService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll(int page, int pageSize)
        {
            var movies = _service.GetAll(page, pageSize);
             
            return Ok(_mapper.Map<List<GetMovieDto>>(movies));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _service.GetById(id);
            
            if (movie == null)
            {
                throw new InvalidOperationException("Movie Not Found") ;
            }

            return Ok(_mapper.Map<GetMovieDto>(movie));
        }

        //[HttpPost]
        //public IActionResult Create(CreateMovieDto movieDto)// error
        //{
        //    _service.Add(_mapper.Map<Movie>(movieDto));

        //    return Ok();

        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, UpdateMovieDto movieDto)//error,
        //{
        //    var existMovie = _service.GetById(id);

        //    if (existMovie == null)
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    movieDto =_service.Update(id, _mapper.Map<UpdateMovieDto>(existMovie));

        //    return Ok(_mapper.Map<GetMovieDto>(movieDto));

        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existMovie = _service.GetById(id);
            if (existMovie == null)
            {
                throw new InvalidOperationException("Movie Not Found");
            }

            _service.Delete(id);
            return NoContent();
        }
    }



}

