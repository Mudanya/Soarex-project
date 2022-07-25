using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.CustomerFeedback;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerFeedbackService
    {
        private readonly IRepositorymanager repository;
        private readonly IMapper mapper;

        public CustomerFeedbackService(IRepositorymanager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CustomerFeedbackDto>> GetCustomerFeedbackAsync()
        {
            IEnumerable<CustomerFeedback> customerFeedback = await repository.CustomerFeedback.GetAllCustomerFeedbacksAsync(trackChanges: false);
            IEnumerable<CustomerFeedbackDto> customerFeedbackDto = mapper.Map<IEnumerable<CustomerFeedbackDto>>(customerFeedback);
            return customerFeedbackDto;
        }

        public async Task<CustomerFeedbackDto> CreateCustomerFeedbackAsync(CustomerFeedbackUpsertDto customerFeedbackUpsertDto)
        {

            CustomerFeedback customerFeedback = mapper.Map<CustomerFeedback>(customerFeedbackUpsertDto);
            repository.CustomerFeedback.CreateCustomerFeedback(customerFeedback);
            await repository.SaveAsync();
            CustomerFeedbackDto customerFeedbackDto = mapper.Map<CustomerFeedbackDto>(customerFeedback);
            return customerFeedbackDto;
        }

        public async Task<CustomerFeedbackDto> UpdateCustomerFeedbackAsync(Guid id,CustomerFeedbackUpsertDto customerFeedbackUpsertDto)
        {
            CustomerFeedback customerFeedback = await repository.CustomerFeedback.GetCustomerFeedbackAsync(id, trackChanges: true);
            if (customerFeedback == null)
                return null;
            CustomerFeedback privacyPolic = mapper.Map(customerFeedbackUpsertDto, customerFeedback);
            repository.CustomerFeedback.UpdateteCustomerFeedback(privacyPolic);
            await repository.SaveAsync();
            CustomerFeedbackDto customerFeedbackDto = mapper.Map<CustomerFeedbackDto>(privacyPolic);
            return customerFeedbackDto;
        }
    }
}
