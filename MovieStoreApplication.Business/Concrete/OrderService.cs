using AutoMapper;
using Microsoft.Extensions.Logging;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Business.DTOs.OrderDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Concrete
{
    public class OrderService :IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository repository, ILogger<OrderService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public ServiceResult Add(OrderDto orderDto)
        {
            var response = _repository.Add(_mapper.Map<Order>(orderDto));

            if (!response)
                _logger.LogInformation("Order not occured");

            return response ? ServiceResult.Success() : ServiceResult.Failed(" Order Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);

            if (!response)
                _logger.LogInformation("Order not deleted");

            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<List<OrderDto>> GetAll()
        {
            var orders = _repository.GetAll();

            if (orders is null)
            {
                _logger.LogInformation("Order not available");
                return ServiceResult<List<OrderDto>>.Failed(null, "Not Found", 404);

            }
            return ServiceResult<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders));
        }

        public ServiceResult<OrderDto> GetById(int id)
        {
            var response = _mapper.Map<OrderDto>(_repository.GetById(id));

            if (response == null)
            {
                _logger.LogInformation("Order not available");
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<OrderDto>.Success(response);
        }

        public ServiceResult<OrderDto> Update(int id, OrderDto orderDto)
        {
            var order = _repository.GetById(id);

            if (order is null)
            {
                _logger.LogInformation("Order not available");
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            var m = _repository.Update(id, _mapper.Map<Order>(order));

            if (m is null)
            {
                _logger.LogInformation("Order not updated");
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<OrderDto>.Success(_mapper.Map<OrderDto>(m));
        }
    }
}
