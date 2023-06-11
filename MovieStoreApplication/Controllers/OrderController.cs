using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Business.DTOs.OrderDTOs;
using System.Collections.Generic;

namespace MovieStoreApplication.Controllers
{
    [Route("orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper, IOrderService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _service.GetAll();

            return Ok(_mapper.Map<List<OrderDto>>(orders));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _service.GetById(id);

            if (order is null)
            {
                return NotFound(order.ErrorMessage);
            }

            return Ok(_mapper.Map<OrderDto>(order));
        }


        [HttpPost]
        public IActionResult Create([FromBody] OrderDto orderDto)
        {
            var response = _service.Add(orderDto);

            if (response.Succeed)
                return NoContent();

            return NotFound(response.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderDto orderDto)
        {
            var response = _service.Update(id, orderDto);

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
