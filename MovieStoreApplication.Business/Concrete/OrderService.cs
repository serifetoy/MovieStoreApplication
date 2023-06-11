using AutoMapper;
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

        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResult Add(OrderDto orderDto)
        {
            var response = _repository.Add(_mapper.Map<Order>(orderDto));
            return response ? ServiceResult.Success() : ServiceResult.Failed(" Order Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<List<OrderDto>> GetAll()
        {
            var orders = _repository.GetAll();

            if (orders is null)
            {
                return ServiceResult<List<OrderDto>>.Failed(null, "Not Found", 404);

            }
            return ServiceResult<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders));
        }

        public ServiceResult<OrderDto> GetById(int id)
        {
            var response = _mapper.Map<OrderDto>(_repository.GetById(id));

            if (response == null)
            {
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<OrderDto>.Success(response);
        }

        public ServiceResult<OrderDto> Update(int id, OrderDto orderDto)
        {
            var order = _repository.GetById(id);

            if (order is null)
            {
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            var m = _repository.Update(id, _mapper.Map<Order>(order));

            if (m is null)
            {
                return ServiceResult<OrderDto>.Failed(null, "Not Found", 404);
            }

            return ServiceResult<OrderDto>.Success(_mapper.Map<OrderDto>(m));
        }
    }
}
