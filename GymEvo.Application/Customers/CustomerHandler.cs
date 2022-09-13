using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymEvo.Application.DTOs;
using GymEvo.Domain.Entity;
using GymEvo.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GymEvo.Application.Customers
{
    public class CustomerHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            var resultReturn = await _uow.CustomerRepository.Find(x => x.IsActive)
                .AsNoTracking()
                //.Include(x => x.UnitMeasure)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return new List<CustomerDto>(resultReturn);
        }

        public async Task<CustomerDto> Get(int Id)
        {
            var customer = await _uow.CustomerRepository.Find(x => x.IsActive && x.CustomerId == Id)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return customer ?? new CustomerDto();
        }

        public async Task<bool> Insert(CustomerDto company)
        {
            company.IsActive = true;

            var result = await _uow.CustomerRepository.CreateAsync(_mapper.Map<Customer>(company));

            await _uow.Save();

            return !string.IsNullOrEmpty(result.CustomerId.ToString());
        }

        public async Task<bool> Update(CustomerDto customerDto)
        {
            var result = _uow.CustomerRepository.Update(_mapper.Map<Customer>(customerDto));

            await _uow.Save();

            return !string.IsNullOrEmpty(result.CustomerId.ToString());
        }

        public async Task<bool> Delete(int Id)
        {
            var customer = await _uow.CustomerRepository
                                            .Find(x => x.CustomerId == Id)
                                            .FirstOrDefaultAsync();

            if (customer == null)
                return false;

            var result = _uow.CustomerRepository.Delete(Id);

            await _uow.Save();

            return !string.IsNullOrEmpty(result.Id.ToString());
        }
    }
}
