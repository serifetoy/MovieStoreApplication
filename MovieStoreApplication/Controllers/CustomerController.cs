﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.CustomerDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper, ICustomerService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CustomerDto customerDto)
        {
            var response = _service.Add(customerDto);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerDto customerDto)
        {
            var result = _service.Update(id, customerDto);

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
