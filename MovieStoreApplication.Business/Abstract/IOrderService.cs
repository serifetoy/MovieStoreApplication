using MovieStoreApplication.Business.DTOs.OrderDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface IOrderService
    {
        ServiceResult Add(OrderDto orderDto);
        ServiceResult<OrderDto> GetById(int id);
        ServiceResult<List<OrderDto>> GetAll();
        ServiceResult<OrderDto> Update(int id, OrderDto orderDto);
        ServiceResult Delete(int id);
    }
}
