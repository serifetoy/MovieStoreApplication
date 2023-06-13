using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.CustomerDTOs;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Abstract
{
    public interface ICustomerService
    {
        ServiceResult Add(CreateCustomerDto customerDto);
        ServiceResult<CustomerDto> Update(int id, CustomerDto customerDto);
        ServiceResult Delete(int id);
    }
}
