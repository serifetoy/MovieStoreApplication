using AutoMapper;
using MovieStoreApplication.Business.Abstract;
using MovieStoreApplication.Business.DTOs.ActorDTOs;
using MovieStoreApplication.Business.DTOs.CustomerDTOs;
using MovieStoreApplication.Business.DTOs.MovieDTOs;
using MovieStoreApplication.Data.Abstract;
using MovieStoreApplication.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreApplication.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, ICustomerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public ServiceResult Add(CustomerDto customerDto)
        {
            var response = _repository.Add(_mapper.Map<Customer>(customerDto));
            return response ? ServiceResult.Success() : ServiceResult.Failed(" Customer Not Found", 404);
        }

        public ServiceResult Delete(int id)
        {
            var response = _repository.Delete(id);
            return response ? ServiceResult.Success() : ServiceResult.Failed("Not Found", 404);
        }

        public ServiceResult<CustomerDto> Update(int id, CustomerDto customerDto)
        {
            var m = _repository.Update(id, _mapper.Map<Customer>(customerDto));

            if (m is null)
            {
                return ServiceResult<CustomerDto>.Failed(null, " Customer Not Found", 404);
            }

            return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(m));
        }
    }
}
